using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ExercisesController(IUnitOfWork unitOfWork, IMapper mapper, IBlobRepository blobRepository, ExerciseManager exerciseManager) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobRepository _blobRepository = blobRepository;
    private readonly ExerciseManager _exerciseManager = exerciseManager;

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
    public async Task<IActionResult> GetExercisesPaged([FromQuery] RequestParams requestParams)
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

    [HttpGet("{exerciseId}", Name = "GetExerciseById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetExerciseById(Guid exerciseId)
    {
        if (exerciseId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Exercise exercise;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId), ["Session", "Medias", "ExerciseRecords"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            exercise = await _unitOfWork.Exercises.Get(
                e => e.CreatorId == currentUserId && e.Id.Equals(exerciseId), ["Session", "Medias", "ExerciseRecords"]);
        }
        var result = _mapper.Map<ExerciseDTO>(exercise);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exerciseDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        if (exerciseDTO.ExerciseRecords.Count == 0 || exerciseDTO.ExerciseRecords.Count != exerciseDTO.Set)
            return BadRequest("ExerciseRecords must be provided and equal to Set.");

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (exerciseDTO.CreatorId != currentUserId) return Forbid("You are not authorized to create this exercise.");

        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            exercise.CreatedAt = DateTimeOffset.Now;

            await _unitOfWork.Exercises.Insert(exercise);
            await _unitOfWork.Save();

            var records = _mapper.Map<IList<ExerciseRecord>>(exerciseDTO.ExerciseRecords);
            records.Select(r => r.OneRepMax = _exerciseManager.CalculateOneRepMax(r.Weight, r.Rep)).ToList();
            records.Select(r => r.ExerciseId = exercise.Id).ToList();
            await _unitOfWork.ExerciseRecords.InsertRange(records);
            await _unitOfWork.Save();

            transaction.Commit();
            return CreatedAtRoute("GetExerciseById", new { exerciseId = exercise.Id }, exercise);
        }
        catch (Exception)
        {
            transaction.Rollback();
            return StatusCode(500, "An error occurred while creating exercise and records");
        }
    }

    //TODO: It should be able to update exercise and its records.
    //[HttpPut("{exerciseId}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> UpdateExercise(Guid exerciseId, [FromBody] UpdateExerciseDTO exerciseDTO)
    //{
    //    if (!ModelState.IsValid || exerciseId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

    //    if (exerciseDTO.ExerciseRecords.Count == 0 || exerciseDTO.ExerciseRecords.Count != exerciseDTO.Set)
    //        return BadRequest("ExerciseRecords must be provided and equal to Set.");

    //    var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId), includes: ["ExerciseRecords"]);
    //    if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

    //    _mapper.Map(exerciseDTO, exercise);
    //    exercise.ModifiedAt = DateTimeOffset.Now;
    //    exercise.ExerciseRecords.Select(er => er.OneRepMax = _exerciseManager.CalculateOneRepMax(er.Weight, er.Rep)).ToList();

    //    var userRoles = User.FindAll(ClaimTypes.Role);
    //    if (userRoles.Any(ur => ur.Value == Role.Admin))
    //    {
    //        _unitOfWork.Exercises.Update(exercise);
    //    }
    //    else
    //    {
    //        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //        if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to update this exercise.");
    //        _unitOfWork.Exercises.Update(exercise);
    //    }
    //    await _unitOfWork.Save();

    //    return NoContent();
    //}

    [HttpPut("{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateExercise(Guid exerciseId, [FromBody] UpdateExerciseDTO exerciseDTO)
    {
        if (!ModelState.IsValid || exerciseId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        if (exerciseDTO.ExerciseRecords.Count == 0 || exerciseDTO.ExerciseRecords.Count != exerciseDTO.Set)
            return BadRequest("ExerciseRecords must be provided and equal to Set.");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId), includes: ["ExerciseRecords"]);
        if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

        _mapper.Map(exerciseDTO, exercise);
        exercise.ModifiedAt = DateTimeOffset.Now;

        exercise.ExerciseRecords.Clear();
        var records = _mapper.Map<IList<ExerciseRecord>>(exerciseDTO.ExerciseRecords);
        records.Select(r => r.OneRepMax = _exerciseManager.CalculateOneRepMax(r.Weight, r.Rep)).ToList();
        records.Select(r => r.ExerciseId = exercise.Id).ToList();
        await _unitOfWork.ExerciseRecords.InsertRange(records);
        
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


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateExercises([FromBody] IEnumerable<UpdateExerciseDTO> exercisesDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        var exercises = _mapper.Map<IEnumerable<Exercise>>(exercisesDTO);
        foreach (var exercise in exercises)
        {
            exercise.ModifiedAt = DateTimeOffset.Now;
            if (exercise.ExerciseRecords.Count == 0 || exercise.ExerciseRecords.Count != exercise.Set)
                return BadRequest("ExerciseRecords must be provided and equal to Set.");
        }

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.Exercises.UpdateRange(exercises);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercisesToUpdate = exercises.Where(e => e.CreatorId == currentUserId);
            _unitOfWork.Exercises.UpdateRange(exercisesToUpdate);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpPut("{exerciseId}/records")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateExerciseRecords(Guid exerciseId, [FromBody] IEnumerable<UpdateExerciseRecordDTO> exerciseRecordsDTO)
    {
        if (!ModelState.IsValid || exerciseId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId));
        if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

        var exerciseRecords = _mapper.Map<IEnumerable<ExerciseRecord>>(exerciseRecordsDTO);

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.ExerciseRecords.UpdateRange(exerciseRecords);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (exercise.CreatorId != currentUserId) return Forbid("You are not authorized to update this exercise.");
            _unitOfWork.ExerciseRecords.UpdateRange(exerciseRecords);
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
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!isAdmin && exercise.CreatorId != currentUserId) return Forbid("You are not authorized to delete this exercise.");
        
        await _unitOfWork.Exercises.Delete(exerciseId);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{exerciseId}/records/{recordId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteExerciseRecord(Guid exerciseId, Guid recordId)
    {
        if (exerciseId == Guid.Empty || recordId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id.Equals(exerciseId), includes: ["ExerciseRecords"]);
        if (exercise == null) return NotFound($"Exercise with id {exerciseId} not found.");

        var record = exercise.ExerciseRecords.FirstOrDefault(er => er.Id.Equals(recordId));
        if (record == null) return NotFound($"Exercise record with id {recordId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!isAdmin && exercise.CreatorId != currentUserId) return Forbid("You are not authorized to delete this exercise.");

        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            await _unitOfWork.ExerciseRecords.Delete(recordId);
            await _unitOfWork.Save();

            if (exercise.ExerciseRecords.Count == 0)
            {
                await _unitOfWork.Exercises.Delete(exerciseId);
                await _unitOfWork.Save();

                transaction.Commit();
                return NoContent();
            }

            exercise.Set--;
            _unitOfWork.Exercises.Update(exercise);
            await _unitOfWork.Save();

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }

        return NoContent();
    }


    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SearchExercises([FromQuery] string searchRequest, [FromQuery] RequestParams requestParams)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");
        
        searchRequest = searchRequest.ToLower();
        IPagedList<Exercise> exercises;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exercises = await _unitOfWork.Exercises.GetPagedList(requestParams,
                e => e.Title.Equals(searchRequest),
                includes: ["Medias"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           exercises = await _unitOfWork.Exercises.GetPagedList(requestParams,
                e => e.CreatorId == currentUserId && 
                e.Title.Equals(searchRequest), 
                includes: ["Medias"]);
        }
        var results = _mapper.Map<IList<ExerciseDTO>>(exercises);

        return Ok(results);
    }

    [HttpGet("sort")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SortExercises([FromQuery] SortOption sortRequest, [FromQuery] RequestParams requestParams)
    {
        var exercises = await _unitOfWork.Exercises.GetPagedList(requestParams,
            orderBy: e => sortRequest switch
            {
                SortOption.Alphabetical => e.OrderBy(exercise => exercise.Title),
                SortOption.ReverseAlphabetical => e.OrderByDescending(exercise => exercise.Title),
                SortOption.MostRecent => e.OrderByDescending(exercise => exercise.CreatedAt),
                SortOption.Oldest => e.OrderBy(exercise => exercise.CreatedAt),
                _ => e.OrderBy(exercise => exercise.Title),
            },
            includes: ["Medias"]);

        var results = _mapper.Map<IList<ExerciseDTO>>(exercises);

        return Ok(results);
    }

    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FilterExercises([FromQuery] ExerciseFilterQuery filterRequest, [FromQuery] RequestParams requestParams)
    {
        if (filterRequest.TargetMuscles.Count == 0 && filterRequest.Equipments.Count == 0) return BadRequest("Submitted data is invalid.");

        var exercises = await _unitOfWork.Exercises.GetPagedList(requestParams, includes: ["Medias"]);

        if (filterRequest.TargetMuscles.Count > 0)
        {
            exercises = (IPagedList<Exercise>)exercises.Where(
                e => filterRequest.TargetMuscles.All(tm => e.TargetMuscles.Contains(tm))).ToList();
        }

        if (filterRequest.Equipments.Count > 0)
        {
            exercises = (IPagedList<Exercise>)exercises.Where(
                e => filterRequest.Equipments.Contains(e.Equipment)).ToList();
        }
        var results = _mapper.Map<IList<ExerciseDTO>>(exercises);

        return Ok(results);
    }

}
