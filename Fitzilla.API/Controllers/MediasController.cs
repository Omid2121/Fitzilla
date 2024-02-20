using AutoMapper;
using Fitzilla.DAL.IRepository;
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

    [HttpGet("GetMediaFiles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMedias(List<string> paths)
    {
        if (paths == null) return BadRequest("Submitted data is invalid.");

        var medias = await _blobRepository.GetBlobFiles(paths);
        if (medias == null) return NotFound("Media not found.");

        return Ok(medias);
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

    [HttpPost("UploadMediaFile")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadMedia([FromForm] IFormFile file)
    {
        if (file == null) return BadRequest("Submitted data is invalid.");

        var path = await _blobRepository.UploadBlobFile(file);
        if (path == null) return BadRequest("Media upload failed.");

        return CreatedAtRoute("GetMedia", new { path }, path);
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

    [HttpPost("UploadMediasToEntity/{entityId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadMediasToEntity(Guid entityId, [FromForm] List<IFormFile> files)
    {
        if (entityId == Guid.Empty || files == null || files.Count == 0)
            return BadRequest("Submitted data is invalid.");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id == entityId, ["Medias"]);
        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id == entityId, ["Medias"]);
        if (exercise == null && exerciseTemplate == null) return NotFound($"Entity with id {entityId} not found.");
        
        var filePathsTasks = files.Select(_blobRepository.UploadBlobFile).ToList();
        await Task.WhenAll(filePathsTasks);
        var filePaths = filePathsTasks.Select(task => task.Result).ToList();

        var medias = filePaths.Select((path, index) => new Media
        {
            Title = files[index].FileName,
            FilePath = path,
            CreatorId = exercise != null ? exercise.CreatorId : exerciseTemplate.CreatorId!
        }).ToList();

        if (exercise != null)
        {
            exercise.Medias = medias;
            _unitOfWork.Exercises.Update(exercise);
        }
        else if (exerciseTemplate != null)
        {
            exerciseTemplate.Medias = medias;
            _unitOfWork.ExerciseTemplates.Update(exerciseTemplate);
        }
        await _unitOfWork.Save();

        return CreatedAtRoute("GetMedia", new { filePaths }, filePaths);
    }

    //TODO: make sure this endpoint returns the correct data
    [HttpGet("GetMediasOfEntity/{entityId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMediasOfEntity(Guid entityId)
    {
        if (entityId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var exercise = await _unitOfWork.Exercises.Get(e => e.Id == entityId, ["Medias"]);
        var exerciseTemplate = await _unitOfWork.ExerciseTemplates.Get(e => e.Id == entityId, ["Medias"]);
        if (exercise == null && exerciseTemplate == null) return NotFound($"Entity with id {entityId} not found.");

        var medias = exercise?.Medias ?? exerciseTemplate!.Medias;
        if (medias == null) return NotFound("Medias not found.");
        
        var blobObjectsTasks = medias.Select(media => _blobRepository.GetBlobFile(media.FilePath)).ToList();
        await Task.WhenAll(blobObjectsTasks);
        var blobObjects = blobObjectsTasks.Select(task => task.Result).ToList();

        return Ok(blobObjects);
    }
}
