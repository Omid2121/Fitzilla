using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SessionsController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSessions()
    {
        IList<Session> sessions;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            sessions = await _unitOfWork.Sessions.GetAll();
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            sessions = await _unitOfWork.Sessions.GetAll(s => s.CreatorId == currentUserId);
        }
        var results = _mapper.Map<IEnumerable<SessionDTO>>(sessions);

        return Ok(results);
    }

    [HttpGet("{sessionId}", Name = "GetSession")]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Session session;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId), new List<string> { "Exercises" });
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            session = await _unitOfWork.Sessions.Get(
                s => s.Id == sessionId && s.CreatorId == currentUserId, new List<string> { "Exercises" });
        }
        var result = _mapper.Map<SessionDTO>(session);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionDTO sessionDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

        var session = _mapper.Map<Session>(sessionDTO);
        //session.CreatorId = currentUserId;
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (session.CreatorId != currentUserId) return Forbid("You are not authorized to create this session.");
        await _unitOfWork.Sessions.Insert(session);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetSession", new { sessionId = session.Id }, session);
    }

    [HttpPut("{sessionId}")]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateSession(Guid sessionId, [FromBody] UpdateSessionDTO sessionDTO)
    {
        if (sessionId == Guid.Empty || !ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Exercise with id {sessionId} not found.");

        _mapper.Map(sessionDTO, session);
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to update this session.");
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpDelete("{sessionId}")]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Exercise with id {sessionId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            await _unitOfWork.Sessions.Delete(sessionId);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to delete this session.");
            await _unitOfWork.Sessions.Delete(sessionId);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpPut("{sessionId}/activate")]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ActivateSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Exercise with id {sessionId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session.IsActive = true;
            session.ActivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to activate this session.");
            session.IsActive = true;
            session.ActivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpPut("{sessionId}/deactivate")]
    [Authorize(Roles = "Admin, Consumer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeactivateSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Exercise with id {sessionId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session.IsActive = false;
            session.DeactivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to deactivate this session.");
            session.IsActive = false;
            session.DeactivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

}
