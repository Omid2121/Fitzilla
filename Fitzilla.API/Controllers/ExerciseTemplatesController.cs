using AutoMapper;
using Fitzilla.BLL.DTOs;
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
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ExerciseTemplatesController(IUnitOfWork unitOfWork, IMapper mapper, IBlobRepository blobRepository) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobRepository _blobRepository = blobRepository;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExerciseTemplates()
    {
        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetAll(includes: ["Medias"]);
        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(results);
    }

    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPagedExerciseTemplates([FromQuery] RequestParams requestParams)
    {
        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetPagedList(requestParams, includes: ["Medias"]);
        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(results);
    }

    [HttpGet("{exerciseTemplateId}", Name = "GetExerciseTemplateById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExerciseTemplateById(Guid exerciseTemplateId)
    {
        if (exerciseTemplateId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(
            e => e.Id.Equals(exerciseTemplateId), ["Medias"]);

        var result = _mapper.Map<ExerciseTemplateDTO>(exerciseTemplate);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseTemplate([FromBody] CreateExerciseTemplateDTO exerciseTemplateDTO, [FromForm] List<IFormFile> files)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        var exerciseTemplate = _mapper.Map<ExerciseTemplate>(exerciseTemplateDTO);
        exerciseTemplate.CreatedAt = DateTimeOffset.Now;

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null || exerciseTemplate.CreatorId != currentUserId)
            return Forbid("You are not authorized to create this exercise template.");

        //TODO: Test following code.
        var transaction = _unitOfWork.BeginTransaction();
        try
        {
            var filePathsTasks = files.Select(_blobRepository.UploadBlobFile).ToList();
            await Task.WhenAll(filePathsTasks);
            var filePaths = filePathsTasks.Select(task => task.Result).ToList();

            var medias = filePaths.Select((path, index) => new Media
            {
                Title = files[index].FileName,
                FilePath = path,
                CreatorId = currentUserId
            }).ToList();

            await _unitOfWork.ExerciseTemplates.Insert(exerciseTemplate);
            await _unitOfWork.Save();
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }

        return CreatedAtRoute("GetExerciseTemplateById", new { exerciseTemplateId = exerciseTemplate.Id }, exerciseTemplate);
    }

    [HttpPost("{exerciseTemplateId}/ratings")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseTemplateRating(Guid exerciseTemplateId, [FromBody] CreateRatingDTO ratingDTO)
    {
        if (!ModelState.IsValid || exerciseTemplateId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(exerciseTemplateId));
        if (exerciseTemplate == null) return NotFound($"Exercise with id {exerciseTemplateId} not found.");

        var rating = _mapper.Map<Rating>(ratingDTO);
        rating.CreatedAt = DateTimeOffset.Now;
        rating.ExerciseTemplateId = exerciseTemplateId;

        await _unitOfWork.Ratings.Insert(rating);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetExerciseTemplateById", new { exerciseTemplateId = exerciseTemplateId }, rating);
    }

    [HttpPut("{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateExerciseTemplate(Guid exerciseTemplateId, [FromBody] UpdateExerciseTemplateDTO exerciseTemplateDTO, [FromForm] List<IFormFile> files)
    {
        if (!ModelState.IsValid || exerciseTemplateId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(exerciseTemplateId));
        if (exerciseTemplate == null) return NotFound($"Exercise with id {exerciseTemplateId} not found.");

        _mapper.Map(exerciseTemplateDTO, exerciseTemplate);
        exerciseTemplate.ModifiedAt = DateTimeOffset.Now;

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (exerciseTemplate.CreatorId != currentUserId) return Forbid("You are not authorized to update this exercise template.");
            _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
        }
        //TODO: make sure it works.
        var filePathes = await _blobRepository.UploadBlobFiles(files);
        for (int i = 0; i < filePathes.Count; i++)
        {
            exerciseTemplate.Medias.Add(new Media { FilePath = filePathes[i], Title = files[i].FileName });
        }

        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteExerciseTemplate(Guid exerciseTemplateId)
    {
        if (exerciseTemplateId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(exerciseTemplateId));
        if (exerciseTemplate == null) return NotFound($"Exercise with id {exerciseTemplateId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            await _unitOfWork.ExerciseTemplates.Delete(exerciseTemplateId);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (exerciseTemplate.CreatorId != currentUserId) return Forbid("You are not authorized to delete this exercise template.");
            await _unitOfWork.ExerciseTemplates.Delete(exerciseTemplateId);
        }
        //TODO: make sure it works.
        var result = _blobRepository.DeleteBlobFiles(exerciseTemplate.Medias.Select(m => m.FilePath).ToList());
        if (result.IsFaulted) return BadRequest(result.Exception.Message);

        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchExerciseTemplates([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

        searchRequest = searchRequest.ToLower();
        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetAll(
            et => et.Title.Equals(searchRequest),
            includes: ["Medias"]);
        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(exerciseTemplates);
    }

    [HttpGet("sort")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SortExerciseTemplates([FromQuery] SortOption sortRequest, [FromQuery] RequestParams requestParams)
    {
        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetPagedList(requestParams,
            orderBy: et => sortRequest switch
            {
                SortOption.Alphabetical => et.OrderBy(exerciseTemplate => exerciseTemplate.Title),
                SortOption.ReverseAlphabetical => et.OrderByDescending(exerciseTemplate => exerciseTemplate.Title),
                SortOption.MostPopular => et.OrderByDescending(exerciseTemplate => exerciseTemplate.Ratings!.Count > 0 ? exerciseTemplate.Ratings.Average(rating => rating.Value) : 0),
                SortOption.MostRecent => et.OrderByDescending(exerciseTemplate => exerciseTemplate.CreatedAt),
                SortOption.Oldest => et.OrderBy(exerciseTemplate => exerciseTemplate.CreatedAt),
                _ => et.OrderBy(exerciseTemplate => exerciseTemplate.Title)
            },
            includes: ["Medias"]);

        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(results);
    }

    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FilterExerciseTemplates([FromQuery] ExerciseFilterQuery filterRequest, [FromQuery] RequestParams requestParams)
    {
        if (filterRequest.TargetMuscles.Count == 0 && filterRequest.Equipments.Count == 0) return BadRequest("Submitted data is invalid.");

        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetPagedList(requestParams, includes: ["Medias"]);

        if (filterRequest.TargetMuscles.Count > 0)
        {
            exerciseTemplates = (IPagedList<ExerciseTemplate>)exerciseTemplates.Where(
                et => et.TargetMuscles.Any(tm => filterRequest.TargetMuscles.Contains(tm))).ToList();
        }

        if (filterRequest.Equipments.Count > 0)
        {
            exerciseTemplates = (IPagedList<ExerciseTemplate>)exerciseTemplates.Where(
                et => filterRequest.Equipments.Contains(et.Equipment)).ToList();
        }

        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(results);
    }
}