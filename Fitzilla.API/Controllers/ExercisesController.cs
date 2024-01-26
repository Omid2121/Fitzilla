using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ExercisesController(IUnitOfWork unitOfWork, IMapper mapper, IBlobRepository blobRepository) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobRepository _blobRepository = blobRepository;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExercises()
    {
        IList<Exercise> exercises;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exercises = await _unitOfWork.Exercises.GetAll(includes: ["Medias"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            exercises = await _unitOfWork.Exercises.GetAll(e => e.CreatorId == currentUserId, 
                includes: ["Medias"]);
        }
        var results = _mapper.Map<IList<ExerciseDTO>>(exercises);
        
        return Ok(results);
    }

    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPagedExercises([FromQuery] RequestParams requestParams)
    {
        IPagedList<Exercise> exercises;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exercises = await _unitOfWork.Exercises.GetPagedList(requestParams, includes: ["Medias"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            exercises = await _unitOfWork.Exercises.GetPagedList(requestParams, e => e.CreatorId == currentUserId,
                includes: ["Medias"]);
        }
        var results = _mapper.Map<IList<ExerciseDTO>> (exercises);

        return Ok(results);
    }

    [HttpGet("{exerciseId}", Name = "GetExercise")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetExercise(Guid exerciseId)
    {
        if (exerciseId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Exercise exercise;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId), ["Session", "Medias"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            exercise = await _unitOfWork.Exercises.Get(
                e => e.CreatorId == currentUserId && e.Id.Equals(exerciseId), ["Session", "Medias"]);
        }
        var result = _mapper.Map<ExerciseDTO>(exercise);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseWithoutSession([FromBody] CreateExerciseDTO exerciseDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        var exercise = _mapper.Map<Exercise>(exerciseDTO);

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to create this exercise.");

        await _unitOfWork.Exercises.Insert(exercise);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetExercise", new { exerciseId = exercise.Id }, exercise);
    }
    
    [HttpPost("session/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseForSession(Guid sessionId, [FromBody] CreateExerciseDTO exerciseDTO)
    {
        if (!ModelState.IsValid || sessionId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Session with id {sessionId} not found.");

        var exercise = _mapper.Map<Exercise>(exerciseDTO);
        //exercise.SessionId = sessionId;

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to create this exercise.");

        await _unitOfWork.Exercises.Insert(exercise);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetExercise", new { exerciseId = exercise.Id }, exercise);
    }

    [HttpPut("{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateExercise(Guid exerciseId, [FromBody] UpdateExerciseDTO exerciseDTO)
    {
        if (!ModelState.IsValid || exerciseId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId));
        if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

        _mapper.Map(exerciseDTO, exercise);

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.Exercises.Update(exercise);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to update this exercise.");
            _unitOfWork.Exercises.Update(exercise);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteExercise(Guid exerciseId)
    {
        if (exerciseId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId));
        if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            await _unitOfWork.Exercises.Delete(exerciseId);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to delete this exercise.");
            await _unitOfWork.Exercises.Delete(exerciseId);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Search([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");
        
        searchRequest = searchRequest.ToLower();
        IList<Exercise> exercises;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
           exercises = await _unitOfWork.Exercises.GetAll(
                e => e.Title.Equals(searchRequest),
                includes: ["Medias"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           exercises = await _unitOfWork.Exercises.GetAll(
                e => e.CreatorId == currentUserId && 
                e.Title.Equals(searchRequest), 
                includes: ["Medias"]);
        }
        var results = _mapper.Map<IList<ExerciseDTO>>(exercises);

        return Ok(results);
    }
}
