using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
public class SessionsController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
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

    [HttpGet("{sessionId}", Name = "GetSessionById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSessionById(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Session session;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId), ["Exercises"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            session = await _unitOfWork.Sessions.Get(
                s => s.Id == sessionId && s.CreatorId == currentUserId, ["Exercises"]);
        }
        var result = _mapper.Map<SessionDTO>(session);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionDTO sessionDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

        var session = _mapper.Map<Session>(sessionDTO);
        //session.CreatorId = currentUserId;
        session.CreatedAt = DateTimeOffset.Now;
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (session.CreatorId != currentUserId) return Forbid("You are not authorized to create this session.");

        var plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(session.PlanId));
        if (plan == null) return NotFound($"Plan with id {session.PlanId} not found.");

        if (plan.Sessions.Count >= 7 || plan.Sessions.Count == plan.SessionsPerWeek) return BadRequest("Plan's sessions are full.");

        await _unitOfWork.Sessions.Insert(session);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetSessionById", new { sessionId = session.Id }, session);
    }

    [HttpPut("{sessionId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSession(Guid sessionId, [FromBody] UpdateSessionDTO sessionDTO)
    {
        if (sessionId == Guid.Empty || !ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Exercise with id {sessionId} not found.");

        _mapper.Map(sessionDTO, session);
        session.ModifiedAt = DateTimeOffset.Now;
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
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ActivateSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Session with id {sessionId} not found.");

        if (session.IsActive) return BadRequest("Session is already active.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session.IsActive = true;
            session.ActivatedAt = DateTimeOffset.Now;
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to activate this session.");
            session.IsActive = true;
            session.ActivatedAt = DateTimeOffset.Now;
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpPut("{sessionId}/finish")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> FinishSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Session with id {sessionId} not found.");

        if (!session.IsActive) return BadRequest("Session is already inactive.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session.IsActive = false;
            session.FinishedAt = DateTimeOffset.Now;
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to finish this session.");
            session.IsActive = false;
            session.FinishedAt = DateTimeOffset.Now;
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpPut("{sessionId}/cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelSession(Guid sessionId)
    {
        if (sessionId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var session = await _unitOfWork.Sessions.Get(s => s.Id.Equals(sessionId));
        if (session == null) return NotFound($"Session with id {sessionId} not found.");

        if (!session.IsActive) return BadRequest("Session is already inactive.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            session.IsActive = false;
            session.ActivatedAt = null;
            _unitOfWork.Sessions.Update(session);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (session.CreatorId != currentUserId) return Forbid("You are not authorized to cancel this session.");
            session.IsActive = false;
            session.ActivatedAt = null;
            _unitOfWork.Sessions.Update(session);
        }
        await _unitOfWork.Save();

        return NoContent();
    }
}
