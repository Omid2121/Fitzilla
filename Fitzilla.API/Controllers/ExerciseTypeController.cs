using AutoMapper;
using Fitzilla.Core.DTOs;
using Fitzilla.Core.IRepository;
using Fitzilla.Core.Models;
using Fitzilla.Core.Services;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq.Expressions;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public ExerciseTypeController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authManager = authManager;
        }

        #region Endpoints allowed for everyone.

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTypes([FromQuery] RequestParams requestParams)
        {
            var exerciseTypes = await _unitOfWork.ExerciseTypes.GetPagedList(requestParams);
            var result = _mapper.Map<IList<ExerciseTypeDTO>>(exerciseTypes);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetExerciseType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseType(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var exercise = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id), new List<string> { "Exercises" });

            var result = _mapper.Map<ExerciseTypeDTO>(exercise);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string searchRequest)
        {
            if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

            var exerciseTypes = await _unitOfWork.ExerciseTypes
                .Search(exerciseType => exerciseType.Name.ToLower()
                .Contains(searchRequest.ToLower()));

            var result = _mapper.Map<IList<ExerciseTypeDTO>>(exerciseTypes);

            return Ok(result);
        }

        #endregion

        #region Endpoints allowed for Authorized users(Admin, Consumer).

        [Authorize (Roles = "Admin,Consumer")]
        [HttpGet("GetExerciseTypesWithRelation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTypesWithRelation([FromQuery] RequestParams requestParams)
        {
            var currentUser = await _authManager.GetCurrentUser(User);

            IEnumerable<ExerciseType> exerciseTypes = await _unitOfWork.ExerciseTypes.GetPagedList(requestParams);
            exerciseTypes = exerciseTypes.Where(e => e.CreatorId == currentUser.Id);
            var result = _mapper.Map<IList<ExerciseTypeDTO>>(exerciseTypes);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("GetExerciseTypeWithRelation/{id}", Name = "GetExerciseTypeWithRelation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTypeWithRelation(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var currentUser = await _authManager.GetCurrentUser(User);

            var exerciseType = await _unitOfWork.ExerciseTypes
                .Get(e => e.Id == id && e.CreatorId == currentUser.Id, new List<string> { "Exercises" });

            var result = _mapper.Map<ExerciseTypeDTO>(exerciseType);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateExerciseType([FromBody] CreateExerciseTypeDTO exerciseTypeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var currentUser = await _authManager.GetCurrentUser(User);

            if (exerciseTypeDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            await _unitOfWork.ExerciseTypes.Insert(exerciseType);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetExerciseType", new { id = exerciseType.Id }, exerciseType);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateExerciseType(Guid id, [FromBody] UpdateExerciseTypeDTO exerciseTypeDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);
            
            var exerciseType = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id));
            if (exerciseType == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exerciseType.CreatorId)) return Forbid();
            
            _mapper.Map(exerciseTypeDTO, exerciseType);
            _unitOfWork.ExerciseTypes.Update(exerciseType);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteExerciseType(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Submitted data is invalid.");

            var exerciseType = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id));
            if (exerciseType == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exerciseType.CreatorId)) return Forbid();

            await _unitOfWork.ExerciseTypes.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> IsAuthorized(string exerciseTypeUserId)
        {
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            return exerciseTypeUserId == currentUser.Id || (userRole == "Admin");
        }

        #endregion

    }
}
