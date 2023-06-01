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
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseTypes([FromQuery] RequestParams requestParams)
        {
            var exerciseTypes = await _unitOfWork.ExerciseTypes.GetPagedList(requestParams);
            var result = _mapper.Map<IList<ExerciseTypeDTO>>(exerciseTypes);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetExerciseType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExerciseType(string id)
        {
            var exercise = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id), new List<string> { "Exercises" });
            var result = _mapper.Map<ExerciseDTO>(exercise);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateExerciseType([FromBody] CreateExerciseTypeDTO exerciseTypeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exerciseType = _mapper.Map<ExerciseType>(exerciseTypeDTO);
            await _unitOfWork.ExerciseTypes.Insert(exerciseType);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetExerciseType", new { id = exerciseType.Id }, exerciseType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateExerciseType(string id, [FromBody] UpdateExerciseTypeDTO exerciseTypeDTO)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id)) return BadRequest(ModelState);
            
            var exerciseType = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id));
            if (exerciseType == null) return BadRequest("Submitted data is invalid.");

            _mapper.Map(exerciseTypeDTO, exerciseType);
            _unitOfWork.ExerciseTypes.Update(exerciseType);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteExerciseType(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Submitted data is invalid.");

            var exerciseType = await _unitOfWork.ExerciseTypes.Get(e => e.Id.Equals(id));
            if (exerciseType == null) return BadRequest("Submitted data is invalid.");

            await _unitOfWork.ExerciseTypes.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
