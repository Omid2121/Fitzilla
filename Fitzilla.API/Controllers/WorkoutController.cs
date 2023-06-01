using AutoMapper;
using Fitzilla.Core.DTOs;
using Fitzilla.Core.IRepository;
using Fitzilla.Core.Models;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class WorkoutController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkoutController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkouts([FromQuery] RequestParams requestParams)
        {
            var workouts = await _unitOfWork.Workouts.GetPagedList(requestParams);
            var result = _mapper.Map<IList<Workout>>(workouts);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetWorkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkout(string id)
        {
            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id));
            var result = _mapper.Map<Workout>(workout);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDTO workoutDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var workout = _mapper.Map<Workout>(workoutDTO);
            await _unitOfWork.Workouts.Insert(workout);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetWorkout", new { id = workout.Id }, workout);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateWorkout(string id, [FromBody] UpdateWorkoutDTO workoutDTO)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id)) return BadRequest(ModelState);

            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id));
            if (workout == null) return BadRequest("Submitted data is invalid.");

            _mapper.Map(workoutDTO, workout);
            _unitOfWork.Workouts.Update(workout);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteWorkout(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var workout = await _unitOfWork.Workouts.Get(w => w.Id.Equals(id));
            if (workout == null) return BadRequest("Submitted data is invalid.");

            await _unitOfWork.Workouts.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
