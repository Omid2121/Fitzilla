using AutoMapper;
using Fitzilla.Core.DTOs;
using Fitzilla.Core.IRepository;
using Fitzilla.Core.Models;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ExerciseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GeExercises([FromQuery] RequestParams requestParams)
        {
            var exercises = await _unitOfWork.Exercises.GetPagedList(requestParams);
            var result = _mapper.Map<IList<ExerciseDTO>>(exercises);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExercise(string id)
        {
            //TODO: Both ExerciseType and Workout should be included, instead of just ExerciseType.
            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id), new List<string> { "ExerciseType" });
            var result = _mapper.Map<ExerciseDTO>(exercise);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exerciseDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_unitOfWork.ExerciseTypes.Get(x => x.Id.Equals(exerciseDTO.ExerciseTypeId)).Result is null) 
                return BadRequest("Submitted data is invalid.");

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            await _unitOfWork.Exercises.Insert(exercise);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetExercise", new { id = exercise.Id }, exercise);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateExercise(string id, [FromBody] UpdateExerciseDTO exerciseDTO)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id)) return BadRequest(ModelState);

            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id));
            if (exercise == null) return BadRequest("Submitted data is invalid.");

            _mapper.Map(exerciseDTO, exercise);
            _unitOfWork.Exercises.Update(exercise);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteExercise(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(id));   
            if (exercise == null) return BadRequest("Submitted data is invalid.");

            await _unitOfWork.Exercises.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        //[Route("ExerciseTypes/search")]
        //[HttpGet]
        //public IActionResult Search(string searchValue)
        //{
        //    if (string.IsNullOrEmpty(searchValue)) return BadRequest();
        //}
    }
}
