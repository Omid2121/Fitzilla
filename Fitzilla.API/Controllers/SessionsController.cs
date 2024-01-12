using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers
{
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
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sessions = await _unitOfWork.Sessions.GetAll(s => s.CreatorId == currentUserId);
            var results = _mapper.Map<IEnumerable<SessionDTO>>(sessions);

            return Ok(results);
        }

        [HttpGet("{sessionId}", Name = "GetSession")]
        [Authorize(Roles = "Admin, Consumer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSession(Guid sessionId)
        {
            if (sessionId == Guid.Empty) return BadRequest("Invalid Id");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _unitOfWork.Sessions.Get(
                s => s.Id == sessionId && s.CreatorId == currentUserId, new List<string> { "Exercises" });
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

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = _mapper.Map<Session>(sessionDTO);
            session.CreatorId = currentUserId;

            await _unitOfWork.Sessions.Insert(session);
            await _unitOfWork.Save();

            var result = _mapper.Map<SessionDTO>(session);

            return CreatedAtRoute("GetSession", new { sessionId = result.Id }, result);
        }

        [HttpPut("{sessionId}")]
        [Authorize(Roles = "Admin, Consumer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSession(Guid sessionId, [FromBody] UpdateSessionDTO sessionDTO)
        {
            if (sessionId == Guid.Empty || !ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var session = await _unitOfWork.Sessions.Get(s => s.Id == sessionId && s.CreatorId == currentUserId);
            if (session == null) return NotFound("Session not found");

            _mapper.Map(sessionDTO, session);
            _unitOfWork.Sessions.Update(session);
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
            if (sessionId == Guid.Empty) return BadRequest("Invalid Id");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _unitOfWork.Sessions.Get(s => s.Id == sessionId && s.CreatorId == currentUserId);
            if (session == null) return NotFound("Session not found");

            await _unitOfWork.Sessions.Delete(session.Id);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("{sessionId}/activate")]
        [Authorize(Roles = "Admin, Consumer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ActivateSession(Guid sessionId)
        {
            if (sessionId == Guid.Empty) return BadRequest("Invalid Id");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _unitOfWork.Sessions.Get(s => s.Id == sessionId && s.CreatorId == currentUserId);
            if (session == null) return NotFound("Session not found");

            session.IsActive = true;
            session.ActivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("{sessionId}/deactivate")]
        [Authorize(Roles = "Admin, Consumer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeactivateSession(Guid sessionId)
        {
            if (sessionId == Guid.Empty) return BadRequest("Invalid Id");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var session = await _unitOfWork.Sessions.Get(s => s.Id == sessionId && s.CreatorId == currentUserId);
            if (session == null) return NotFound("Session not found");

            session.IsActive = false;
            session.DeactivatedAt = DateTime.UtcNow;
            _unitOfWork.Sessions.Update(session);
            await _unitOfWork.Save();

            return NoContent();
        }

    }
}
