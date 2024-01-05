using AutoMapper;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.DTOs;
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
    public class WorkoutController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public WorkoutController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authManager = authManager;
        }

        #region Endpoints allowed for Authorized users(Admin, Consumer).

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWorkouts([FromQuery] string? includeProperties = null, [FromQuery] string? orderBy = null)
        {
            List<string>? includeList = !string.IsNullOrEmpty(includeProperties) ? includeProperties.Split(',').ToList() : null;
            Func<IQueryable<Workout>, IOrderedQueryable<Workout>>? orderByExpression = null;
            IEnumerable<Workout> workouts = await _unitOfWork.Workouts.GetAll(expression: null, orderByExpression, includeList);
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);
            if (userRole != "Admin")
            {
                workouts = workouts.Where(w => w.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<WorkoutDTO>>(workouts);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkouts([FromQuery] RequestParams requestParams)
        {
            IEnumerable<Workout> workouts = await _unitOfWork.Workouts.GetPagedList(requestParams);
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            if (userRole != "Admin")
            {
                workouts = workouts.Where(w => w.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<WorkoutDTO>>(workouts);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("{id}", Name = "GetWorkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkout(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id), new List<string> { "Exercises" });

            if (!await IsAuthorized(workout.CreatorId)) return Forbid();

            var result = _mapper.Map<WorkoutDTO>(workout);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDTO workoutDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var currentUser = await _authManager.GetCurrentUser(User);
            if (workoutDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var workout = _mapper.Map<Workout>(workoutDTO);
            await _unitOfWork.Workouts.Insert(workout);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetWorkout", new { id = workout.Id }, workout);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateWorkout(Guid id, [FromBody] UpdateWorkoutDTO workoutDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id));
            if (workout == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(workout.CreatorId)) return Forbid();

            _mapper.Map(workoutDTO, workout);
            _unitOfWork.Workouts.Update(workout);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id));
            if (workout == null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(workout.CreatorId)) return Forbid();

            await _unitOfWork.Workouts.Delete(id);
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

            IEnumerable<Workout>workouts = await _unitOfWork.Workouts
                .Search(workout => workout.Name.ToLower()
                .Contains(searchRequest.ToLower()));

            if (userRole != "Admin")
            {
                workouts = workouts.Where(w => w.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<WorkoutDTO>>(workouts);

            return Ok(result);
        }

        private async Task<bool> IsAuthorized(string workoutUserId)
        {
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            return workoutUserId == currentUser.Id || (userRole == "Admin");
        }
        #endregion
    }
}
