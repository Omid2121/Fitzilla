using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.IRepository;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediasController : ControllerBase
{
    private readonly IBlobRepository _blobRepository;
    private readonly IMapper _mapper;

    public MediasController(IBlobRepository blobRepository, IMapper mapper)
    {
        _blobRepository = blobRepository;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("ListBlobs")]
    public async Task<IActionResult> ListBlobs()
    {
        var blobs = await _blobRepository.ListBlobs();
        return Ok(blobs);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("GetMediaFile", Name = "GetMedia")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMedia(string path)
    {
        if (path == null) return BadRequest("Submitted data is invalid.");

        var media = await _blobRepository.GetBlobFile(path);
        if (media == null) return NotFound("Media not found.");

        return File(media.Content, media.ContentType);
    }

    [Authorize(Roles = "Admin,Consumer")]
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

    [Authorize(Roles = "Admin,Consumer")]
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
