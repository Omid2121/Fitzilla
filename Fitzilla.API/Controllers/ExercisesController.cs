using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
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
    public class ExercisesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobRepository _blobRepository;

        public ExercisesController(IUnitOfWork unitOfWork, IMapper mapper, IBlobRepository blobRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobRepository = blobRepository;
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExercises([FromQuery] RequestParams requestParams)
        {
            IEnumerable<Exercise> exercises = await _unitOfWork.Exercises.GetPagedList(requestParams);
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            if (userRole != "Admin")
            {
                exercises = exercises.Where(e => e.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<ExerciseDTO>>(exercises);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("{id}", Name = "GetExercise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExercise(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            
            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id), new List<string> { "Session" });

            if (!await IsAuthorized(exercise.CreatorId)) return Forbid();

            var result = _mapper.Map<ExerciseDTO>(exercise);
            
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exerciseDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //if (!await ExerciseTypeExists(exerciseDTO.ExerciseTypeId))
            //    return BadRequest("Submitted data is invalid.");

            var currentUser = await _authManager.GetCurrentUser(User);
            if (exerciseDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            await _unitOfWork.Exercises.Insert(exercise);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetExercise", new { id = exercise.Id }, exercise);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] UpdateExerciseDTO exerciseDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id));
            if (exercise == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exercise.CreatorId)) return Forbid(); 

            _mapper.Map(exerciseDTO, exercise);
            _unitOfWork.Exercises.Update(exercise);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id));   
            if (exercise == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(exercise.CreatorId)) return Forbid();

            await _unitOfWork.Exercises.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string searchRequest)
        {
            if (string.IsNullOrEmpty(searchRequest)) 
                return BadRequest("Submitted data is invalid.");

            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            IEnumerable<Exercise> exercises = await _unitOfWork.Exercises.Search(exercise =>
            exercise.Title.ToLower().Contains(searchRequest.ToLower()));

            if (userRole != "Admin")
            {
                exercises = exercises.Where(exercise => exercise.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<ExerciseDTO>>(exercises);

            return Ok(result);
        }

        private async Task<bool> ExerciseTemplateExists(Guid? id)
        {
            return await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(id)) != null;
        }

    }
}
