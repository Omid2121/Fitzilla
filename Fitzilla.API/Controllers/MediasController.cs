using AutoMapper;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Consumer")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class MediasController(IUnitOfWork unitOfWork, IBlobRepository blobRepository, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IBlobRepository _blobRepository = blobRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet("ListBlobs")]
    public async Task<IActionResult> ListBlobs()
    {
        var blobs = await _blobRepository.ListBlobs();
        return Ok(blobs);
    }

    [HttpGet("GetMediaFile", Name = "GetMediaByPath")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMediaByPath(string path)
    {
        if (path == null) return BadRequest("Submitted data is invalid.");

        var media = await _blobRepository.GetBlobFile(path);
        if (media == null) return NotFound("Media not found.");

        return File(media.Content, media.ContentType);
    }

    [HttpGet("GetMediasOfExerciseTemplate/{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMediasOfExerciseTemplate(Guid exerciseTemplateId)
    {
        if (exerciseTemplateId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id == exerciseTemplateId, ["Medias"]);
        if (exerciseTemplate == null) return NotFound($"exercise template with id {exerciseTemplateId} not found.");

        var medias = exerciseTemplate.Medias;
        if (medias == null) return NotFound("Medias not found.");

        //var taskResponses = medias.Select(media => _blobRepository.GetBlobFile(media.FilePath)).ToList();
        //await Task.WhenAll(taskResponses);
        //var blobResponses = taskResponses.Select(task => task.Result).ToList();
        var blobObjects = await _blobRepository.GetBlobFiles(medias.Select(media => media.FilePath).ToList());

        return Ok(blobObjects);
    }

    [HttpPost("UploadMediaToExerciseTemplate/{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadMediaToExerciseTemplate(Guid exerciseTemplateId, IFormFile file)
    {
        if (exerciseTemplateId == Guid.Empty || file == null) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id == exerciseTemplateId, ["Medias"]);
        if (exerciseTemplate == null) return NotFound($"Exercise template with id {exerciseTemplateId} not found.");
        
        BlobResponse blobResponse = await _blobRepository.UploadBlobAsync(file);
        if (blobResponse == null) return BadRequest("Error occurred while uploading media.");

        if (exerciseTemplate.Medias == null) exerciseTemplate.Medias = new List<Media>();
        exerciseTemplate.Medias.Add(new Media
        {
            Title = blobResponse.BlobObject.Name!,
            FilePath = blobResponse.BlobObject.Uri!,
            CreatorId = exerciseTemplate.CreatorId!
        });

        _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
        await _unitOfWork.Save();

        return Ok(blobResponse);
    }

    [HttpPost("UploadMediasToExerciseTemplate/{exerciseTemplateId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadMediasToExerciseTemplate(Guid exerciseTemplateId, List<IFormFile> files)
    {
        if (exerciseTemplateId == Guid.Empty || files == null || files.Count == 0) return BadRequest("Submitted data is invalid.");

        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(et => et.Id == exerciseTemplateId, ["Medias"]);
        if (exerciseTemplate == null) return NotFound($"Exercise template with id {exerciseTemplateId} not found.");

        var taskResponses = files.Select(_blobRepository.UploadBlobAsync).ToList();
        await Task.WhenAll(taskResponses);
        var blobResponses = taskResponses.Select(task => task.Result).ToList();

        var medias = blobResponses.Select(response => new Media
        {
            Title = response.BlobObject.Name!,
            FilePath = response.BlobObject.Uri!,
            CreatorId = exerciseTemplate.CreatorId!
        }).ToList();

        exerciseTemplate.Medias = medias;
        _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
        
        await _unitOfWork.Save();

        return Ok(blobResponses);
    }

    [HttpDelete("DeleteMediaFile")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteMedia(string path)
    {
        if (path == null) return BadRequest("Submitted data is invalid.");

        _blobRepository.DeleteBlobFile(path);

        return NoContent();
    }
}
