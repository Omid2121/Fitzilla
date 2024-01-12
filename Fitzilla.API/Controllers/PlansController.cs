using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PlansController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlansController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlans([FromQuery] RequestParams requestParams)
        {
            var plans = await _unitOfWork.Plans.GetPagedList(requestParams);
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            if (userRole != "Admin")
            {
                plans = plans.Where(w => w.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<PlanDTO>>(plans);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("{id}", Name = "GetPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPlan(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var plan = await _unitOfWork.Plans.Get(w => w.Id.Equals(id), new List<string> { "Sessions" });
            
            if (!await IsAuthorized(plan.CreatorId)) return Forbid();

            var result = _mapper.Map<PlanDTO>(plan);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePlan([FromBody] CreatePlanDTO planDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var currentUser = await _authManager.GetCurrentUser(User);
            if (planDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var plan = _mapper.Map<Plan>(planDTO);
            await _unitOfWork.Plans.Insert(plan);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetPlan", new { id = plan.Id }, plan);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePlan(Guid id, [FromBody] UpdatePlanDTO planDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var plan = await _unitOfWork.Plans.Get(w => w.Id.Equals(id));
            if (plan == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(plan.CreatorId)) return Forbid();

            _mapper.Map(planDTO, plan);
            _unitOfWork.Plans.Update(plan);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var plan = await _unitOfWork.Plans.Get(w => w.Id.Equals(id));
            if (plan == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(plan.CreatorId)) return Forbid();

            await _unitOfWork.Plans.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string searchRequest, string userId)
        {
            if (string.IsNullOrEmpty(searchRequest) || string.IsNullOrEmpty(userId))
                return BadRequest("Submitted data is invalid.");

            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            IEnumerable<Plan> plans = await _unitOfWork.Plans
                .Search(plan => plan.Title.ToLower()
                .Contains(searchRequest.ToLower()));
            
            if (userRole != "Admin")
            {
                plans =plans.Where(w => w.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<PlanDTO>>(plans);

            return Ok(result);
        }

    }
}
