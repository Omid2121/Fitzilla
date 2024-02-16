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
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class PlansController(IUnitOfWork unitOfWork, IMapper mapper, PlanManager planManager) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly PlanManager _planManager = planManager;

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

    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPagedPlans([FromQuery] RequestParams requestParams)
    {
        IPagedList<Plan> plans;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plans = await _unitOfWork.Plans.GetPagedList(requestParams);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plans = await _unitOfWork.Plans.GetPagedList(requestParams, p => p.CreatorId == currentUserId);
        }
        var results = _mapper.Map<IList<PlanDTO>>(plans);

        return Ok(results);
    }

    [HttpGet("{planId}", Name = "GetPlanById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPlanById(Guid planId)
    {
        if (planId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Plan plan;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId), ["Sessions"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plan = await _unitOfWork.Plans.Get(p => p.Id.Equals(planId) && p.CreatorId == currentUserId, ["Sessions"]);
        }
        var result = _mapper.Map<PlanDTO>(plan);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanDTO planDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload. {ModelState}");

        if (planDTO.SessionsPerWeek < 1 || planDTO.SessionsPerWeek > 7) return BadRequest("SessionsPerWeek must be between 1 and 7.");
        if (planDTO.DurationInWeeks < 1 || planDTO.DurationInWeeks > 52) return BadRequest("DurationInWeeks must be between 1 and 52.");

        var plan = _mapper.Map<Plan>(planDTO);
        plan.CreatedAt = DateTimeOffset.Now;
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (plan.CreatorId != currentUserId) return Forbid("You are not authorized to create this plan.");

        await _unitOfWork.Plans.Insert(plan);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetPlanById", new { planId = plan.Id }, plan);
    }

    [HttpPut("{planId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePlan(Guid planId, [FromBody] UpdatePlanDTO planDTO)
    {
        if (!ModelState.IsValid || planId == Guid.Empty) return BadRequest($"Invalid payload. {ModelState}");

        if (planDTO.SessionsPerWeek < 1 || planDTO.SessionsPerWeek > 7) return BadRequest("SessionsPerWeek must be between 1 and 7.");
        if (planDTO.DurationInWeeks < 1 || planDTO.DurationInWeeks > 52) return BadRequest("DurationInWeeks must be between 1 and 52.");
        
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(c => c.Value == Role.Admin))
        {
            var plan = await _unitOfWork.Plans.Get(w => w.Id.Equals(planId));
            if (plan == null) return NotFound($"Plan with id {planId} not found.");
            _mapper.Map(planDTO, plan);
            plan.ModifiedAt = DateTimeOffset.Now;
            _unitOfWork.Plans.Update(plan);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var plan = await _unitOfWork.Plans.Get(w => w.Id.Equals(planId) && w.CreatorId == currentUserId);
            if (plan == null) return NotFound($"Plan with id {planId} not found.");
            _mapper.Map(planDTO, plan);
            plan.ModifiedAt = DateTimeOffset.Now;
            _unitOfWork.Plans.Update(plan);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

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

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchPlans([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

        searchRequest = searchRequest.ToLower();
        IList<Plan> plans;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plans = await _unitOfWork.Plans.GetAll(
                 p => p.Title.ToLower().Equals(searchRequest));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plans = await _unitOfWork.Plans.GetAll(
                 p => p.CreatorId == currentUserId &&
                 p.Title.Equals(searchRequest));
        }
        var results = _mapper.Map<IList<PlanDTO>>(plans);

        return Ok(results);
    }

    [HttpGet("sort")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SortPlans([FromQuery] SortOption sortOption, [FromQuery] RequestParams requestParams)
    {
        IPagedList<Plan> plans;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            plans = await _unitOfWork.Plans.GetPagedList(requestParams,
                orderBy: queryPlans => _planManager.SortPlansByOptions(sortOption, queryPlans));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            plans = await _unitOfWork.Plans.GetPagedList(requestParams,
                plan => plan.CreatorId == currentUserId,
                orderBy: queryPlans => _planManager.SortPlansByOptions(sortOption, queryPlans));
        }
        var results = _mapper.Map<IList<PlanDTO>>(plans);

        return Ok(results);
    }
}