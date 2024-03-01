using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class MacrosController(IUnitOfWork unitOfWork, IMapper mapper, MacroManager macroManager, UserManager<User> userManager) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly MacroManager _macroManager = macroManager;
    private readonly UserManager<User> _userManager = userManager;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMacros()
    {
        IList<Macro> macros;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macros = await _unitOfWork.Macros.GetAll();
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macros = await _unitOfWork.Macros.GetAll(m => m.CreatorId == currentUserId);
        }
        var results = _mapper.Map<IList<MacroDTO>>(macros);

        return Ok(results);
    }

    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMacrosPaged([FromQuery] RequestParams requestParams)
    {
        IPagedList<Macro> macros;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macros = await _unitOfWork.Macros.GetPagedList(requestParams);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macros = await _unitOfWork.Macros.GetPagedList(requestParams, m => m.CreatorId == currentUserId);
        }
        var results = _mapper.Map<IList<MacroDTO>>(macros);

        return Ok(results);
    }
    
    [HttpGet("{macroId}", Name = "GetMacroById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMacroById(Guid macroId)
    {
        if (macroId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Macro macro;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId));
        }
        var result = _mapper.Map<MacroDTO>(macro);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMacro([FromBody] CreateMacroDTO macroDTO)
    {
        if (!ModelState.IsValid) return BadRequest($"Invalid payload: {ModelState}");

        var macro = _mapper.Map<Macro>(macroDTO);
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return BadRequest("User not found.");

        if (macro.CreatorId != currentUser.Id) return Forbid("You are not authorized to create this macro.");

        if (macro.GoalWeight < 0 || macro.GoalWeight > 1000) return BadRequest("Invalid goal weight.");

        if (!_macroManager.IsGoalTypeAlinesGoalWeight(macro.GoalType, macro.GoalWeight, currentUser.Weight))
            return BadRequest("Goal type and goal weight do not align.");

        macro = _macroManager.CalculateMacro(macro, currentUser);
        if (macro is null) return BadRequest("Invalid payload.");
        
        macro = _macroManager.CalculateMacroCycleLength(macro, currentUser.Weight);
        macro.CreatedAt = DateTimeOffset.Now;

        await _unitOfWork.Macros.Insert(macro);
        await _unitOfWork.Save();

        var result = _mapper.Map<MacroDTO>(macro);

        return CreatedAtRoute("GetMacroById", new { macroId = result.Id }, result);
    }

    [HttpPut("{macroId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateMacro(Guid macroId, [FromBody] UpdateMacroDTO macroDTO)
    {
        if (!ModelState.IsValid || macroId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return BadRequest("User not found.");
        
        var userRoles = User.FindAll(ClaimTypes.Role);
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        if (!isAdmin && macroDTO.CreatorId != currentUser.Id) return Forbid("You are not authorized to update this macro.");

        if (macroDTO.GoalWeight < 0 || macroDTO.GoalWeight > 1000) return BadRequest("Invalid goal weight.");

        if (!_macroManager.IsGoalTypeAlinesGoalWeight(macroDTO.GoalType, macroDTO.GoalWeight, currentUser.Weight))
            return BadRequest("Goal type and goal weight do not align.");

        var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId));
        if (macro is null) return NotFound($"Exercise with id {macroId} not found.");

        _mapper.Map(macroDTO, macro);
        macro = _macroManager.CalculateMacro(macro, currentUser);
        if (macro is null) return BadRequest("Invalid payload.");

        macro = _macroManager.CalculateMacroCycleLength(macro, currentUser.Weight);
        macro.ModifiedAt = DateTimeOffset.Now;
        _unitOfWork.Macros.Update(macro);
        await _unitOfWork.Save();
        
        return NoContent();
    }

    [HttpDelete("{macroId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteMacro(Guid macroId)
    {
        if (macroId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId));
        if (macro == null) return NotFound($"Exercise with id {macroId} not found.");

        var userRoles = User.FindAll(ClaimTypes.Role);
        bool isAdmin = userRoles.Any(ur => ur.Value == Role.Admin);
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!isAdmin && macro.CreatorId != currentUserId) return Forbid("You are not authorized to delete this macro.");

        await _unitOfWork.Macros.Delete(macroId);
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchMacros([FromQuery] string searchRequest)
    {
        if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

        searchRequest = searchRequest.ToLower();
        IList<Macro> macros;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macros = await _unitOfWork.Macros.GetAll(
                m => m.Title.Equals(searchRequest));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macros = await _unitOfWork.Macros.GetAll(
                m => m.CreatorId == currentUserId && 
                m.Title.Equals(searchRequest));
        }
        var results = _mapper.Map<IList<MacroDTO>>(macros);

        return Ok(results);
    }

    [HttpGet("sort")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SortMacros([FromQuery] SortOption sortOption, [FromQuery] RequestParams requestParams)
    {
        IPagedList<Macro> macros;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macros = await _unitOfWork.Macros.GetPagedList(requestParams,
                orderBy: m => _macroManager.SortMacrosByOptions(sortOption, m));
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macros = await _unitOfWork.Macros.GetPagedList(requestParams,
                m => m.CreatorId == currentUserId,
                orderBy: m => _macroManager.SortMacrosByOptions(sortOption, m));
        }
        var results = _mapper.Map<IList<MacroDTO>>(macros);

        return Ok(results);
    }

    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FilterMacros([FromQuery] MacroFilterQuery filterQuery, [FromQuery] RequestParams requestParams)
    {
        if (filterQuery.goalTypes.Count == 0 && filterQuery.ActivityLevels.Count == 0) return BadRequest("Submitted data is invalid.");

        IPagedList<Macro> macros;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macros = await _unitOfWork.Macros.GetPagedList(requestParams);
            macros = _macroManager.FilterMacrosByQuery(filterQuery, macros);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macros = await _unitOfWork.Macros.GetPagedList(requestParams, m => m.CreatorId == currentUserId);
            macros = _macroManager.FilterMacrosByQuery(filterQuery, macros);
        }
        var results = _mapper.Map<IList<MacroDTO>>(macros);

        return Ok(results);
    }
}
