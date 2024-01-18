using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class PlansController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlansController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlans()
    {
        IList<Plan> plans;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plans = await _unitOfWork.Plans.GetAll();
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plans = await _unitOfWork.Plans.GetAll(p => p.CreatorId == currentUserId);
        }
        var results = _mapper.Map<IList<PlanDTO>>(plans);

        return Ok(results);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("{planId}", Name = "GetPlan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPlan(Guid planId)
    {
        if (planId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Plan plan;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId), new List<string> { "Sessions" });
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId) && p.CreatorId == currentUserId, new List<string> { "Sessions" });
        }
        var result = _mapper.Map<PlanDTO>(plan);

        return Ok(result);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanDTO planDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        var plan = _mapper.Map<Plan>(planDTO);

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (plan.CreatorId != currentUserId) return Forbid("You are not authorized to create this plan.");
        await _unitOfWork.Plans.Insert(plan);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetPlan", new { planId = plan.Id }, plan);
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpPut("{planId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePlan(Guid planId, [FromBody] UpdatePlanDTO planDTO)
    {
        if (!ModelState.IsValid || planId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId));
        if (plan == null) return NotFound($"Exercise with id {planId} not found.");

        _mapper.Map(planDTO, plan);

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (!userRoles.Any(ur => ur.Value == Role.Admin))
        {
            _unitOfWork.Plans.Update(plan);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (plan.CreatorId != currentUserId) return Forbid("You are not authorized to update this plan.");
            _unitOfWork.Plans.Update(plan);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpDelete("{planId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePlan(Guid planId)
    {
        if (planId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId));
        if (plan == null) return NotFound($"Exercise with id {planId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            await _unitOfWork.Plans.Delete(planId);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (plan.CreatorId != currentUserId) return Forbid("You are not authorized to delete this plan.");
            await _unitOfWork.Plans.Delete(planId);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [Authorize(Roles = "Admin,Consumer")]
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

        searchRequest = searchRequest.ToLower();
        IList<Plan> plans;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plans = await _unitOfWork.Plans.GetAll(
                 p => p.Title.Equals(searchRequest));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plans = await _unitOfWork.Plans.GetAll(
                 p => p.CreatorId == currentUserId &&
                 p.Title.Equals(searchRequest));
        }
        var results = _mapper.Map<IList<ExerciseDTO>>(plans);

        return Ok(results);
    }

}
