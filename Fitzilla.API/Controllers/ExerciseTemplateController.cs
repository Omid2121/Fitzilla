using AutoMapper;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.DTOs;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ExerciseTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public ExerciseTemplateController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authManager = authManager;
        }

        #region Endpoints allowed for everyone.

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTemplates([FromQuery] RequestParams requestParams)
        {
            var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetPagedList(requestParams);
            var result = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetExerciseTemplate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTemplate(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(id), new List<string> { "Exercises" });

            var result = _mapper.Map<ExerciseTemplateDTO>(exerciseTemplate);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string searchRequest)
        {
            if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

            var exerciseTemplates = await _unitOfWork.ExerciseTemplates
                .Search(exerciseTemplate => exerciseTemplate.Name.ToLower()
                .Contains(searchRequest.ToLower()));

            var result = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

            return Ok(result);
        }

        #endregion

        #region Endpoints allowed for Authorized users(Admin, Consumer).

        [Authorize (Roles = "Admin,Consumer")]
        [HttpGet("GetExerciseTemplatesWithRelation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTemplatesWithRelation([FromQuery] RequestParams requestParams)
        {
            var currentUser = await _authManager.GetCurrentUser(User);

            IEnumerable<ExerciseTemplate> exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetPagedList(requestParams);
            exerciseTemplates = exerciseTemplates.Where(e => e.CreatorId == currentUser.Id);
            var result = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("GetExerciseTemplateWithRelation/{id}", Name = "GetExerciseTemplateWithRelation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTemplateWithRelation(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var currentUser = await _authManager.GetCurrentUser(User);

            var exerciseTemplate = await _unitOfWork.ExerciseTemplates
                .Get(e => e.Id == id && e.CreatorId == currentUser.Id, new List<string> { "Exercises" });

            var result = _mapper.Map<ExerciseTemplateDTO>(exerciseTemplate);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateExerciseTemplate([FromBody] CreateExerciseTemplateDTO exerciseTemplateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var currentUser = await _authManager.GetCurrentUser(User);

            if (exerciseTemplateDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var exerciseTemplate = _mapper.Map<ExerciseTemplate>(exerciseTemplateDTO);
            await _unitOfWork.ExerciseTemplates.Insert(exerciseTemplate);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetExerciseTemplate", new { id = exerciseTemplate.Id }, exerciseTemplate);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateExerciseTemplate(Guid id, [FromBody] UpdateExerciseTemplateDTO exerciseTemplateDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);
            
            var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(id));
            if (exerciseTemplate == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exerciseTemplate.CreatorId)) return Forbid();
            
            _mapper.Map(exerciseTemplateDTO, exerciseTemplate);
            _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteExerciseTemplate(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Submitted data is invalid.");

            var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(id));
            if (exerciseTemplate == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exerciseTemplate.CreatorId)) return Forbid();

            await _unitOfWork.ExerciseTemplates.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> IsAuthorized(string exerciseTemplateUserId)
        {
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            return exerciseTemplateUserId == currentUser.Id || (userRole == "Admin");
        }

        #endregion

    }
}
