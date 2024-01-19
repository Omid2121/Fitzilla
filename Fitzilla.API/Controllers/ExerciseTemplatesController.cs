﻿using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ExerciseTemplatesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBlobRepository _blobRepository;

    public ExerciseTemplatesController(IUnitOfWork unitOfWork, IMapper mapper, IBlobRepository blobRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _blobRepository = blobRepository;
    }


    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExerciseTemplates()
    {
        var exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetAll(includes: new List<string> { "Medias" });
        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(results);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("{exerciseTemplateId}", Name = "GetExerciseTemplate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExerciseTemplate(Guid exerciseTemplateId)
    {
        if (exerciseTemplateId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(
            e => e.Id.Equals(exerciseTemplateId), new List<string> { "Medias" });

        var result = _mapper.Map<ExerciseTemplateDTO>(exerciseTemplate);

        return Ok(result);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseTemplate([FromBody] CreateExerciseTemplateDTO exerciseTemplateDTO, [FromForm] List<IFormFile> files)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");
        
        var exerciseTemplate = _mapper.Map<ExerciseTemplate>(exerciseTemplateDTO);

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (exerciseTemplate.CreatorId == currentUserId) 
            return Forbid("You are not authorized to create this exercise template.");

        //foreach (var file in files)
        //{
        //    var filePath = await _blobRepository.UploadBlobFile(file);
        //    exerciseTemplate.Medias = new List<Media> { new Media { FilePath = filePath, Title = file.FileName } };
        //}

        var filePathes = await _blobRepository.UploadBlobFiles(files);
        for (int i = 0; i < filePathes.Count; i++)
        {
            exerciseTemplate.Medias = new List<Media> { new Media { FilePath = filePathes[i], Title = files[i].FileName } };
        }
        
        await _unitOfWork.ExerciseTemplates.Insert(exerciseTemplate);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetExerciseTemplate", new { exerciseTemplateId = exerciseTemplate.Id }, exerciseTemplate);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpPut("{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateExerciseTemplate(Guid exerciseTemplateId, [FromBody] UpdateExerciseTemplateDTO exerciseTemplateDTO, [FromForm] List<IFormFile> files)
    {
        if (!ModelState.IsValid || exerciseTemplateId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id.Equals(exerciseTemplateId));
        if (exerciseTemplate == null) return NotFound($"Exercise with id {exerciseTemplateId} not found.");

        _mapper.Map(exerciseTemplateDTO, exerciseTemplate);

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

    [Authorize(Roles = "Admin,Consumer")]
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

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

        IList<ExerciseTemplate> exerciseTemplates;
        searchRequest = searchRequest.ToLower();
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetAll(
                et => et.Title.Equals(searchRequest),
                includes: new List<string> { "Medias" });
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            exerciseTemplates = await _unitOfWork.ExerciseTemplates.GetAll(
                et => et.CreatorId == currentUserId &&
                et.Title.Equals(searchRequest),
                includes: new List<string> { "Medias" });
        }
        var results = _mapper.Map<IList<ExerciseTemplateDTO>>(exerciseTemplates);

        return Ok(exerciseTemplates);
    }
}
