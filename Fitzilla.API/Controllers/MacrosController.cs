using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Consumer")]
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
    public async Task<IActionResult> GetPagedMacros([FromQuery] RequestParams requestParams)
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

    [HttpGet("{macroId}", Name = "GetMacro")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMacro(Guid macroId)
    {
        if (macroId == Guid.Empty) return BadRequest("Submitted data is invalid.");

        Macro macro;
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId), includes: ["NutritionInfo"]);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId), includes: ["NutritionInfo"]);
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

        //var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (macro.CreatorId != currentUser.Id) return Forbid("You are not authorized to create this macro.");

        macro = _macroManager.CalculateMacro(macro, currentUser);
        if (macro is null) return BadRequest("Invalid payload.");
        
        macro = _macroManager.CalculateMacroCycleLength(macro, currentUser.Weight);
        macro.CreatedAt = DateTime.Now;

        await _unitOfWork.Macros.Insert(macro);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetMacro", new { macroId = macro.Id }, macro);
    }

    [HttpPut("{macroId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateMacro(Guid macroId, [FromBody] UpdateMacroDTO macroDTO)
    {
        if (!ModelState.IsValid || macroId == Guid.Empty) return BadRequest($"Invalid payload: {ModelState}");

        var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(macroId));
        if (macro is null) return NotFound($"Exercise with id {macroId} not found.");

        _mapper.Map(macroDTO, macro);
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return BadRequest("User not found.");
        
        var userRoles = User.FindAll(ClaimTypes.Role);
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {   
            macro = _macroManager.CalculateMacro(macro, currentUser);
            if (macro is null) return BadRequest("Invalid payload.");

            macro = _macroManager.CalculateMacroCycleLength(macro, currentUser.Weight);
            macro.ModifiedAt = DateTime.Now;
            _unitOfWork.Macros.Update(macro);
        }
        else
        {
            //var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (macro.CreatorId != currentUser.Id) return Forbid("You are not authorized to update this macro.");
            macro = _macroManager.CalculateMacro(macro, currentUser);
            if (macro is null) return BadRequest("Invalid payload.");

            macro = _macroManager.CalculateMacroCycleLength(macro, currentUser.Weight);
            macro.ModifiedAt = DateTime.Now;
            _unitOfWork.Macros.Update(macro);
        }
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
        if (userRoles.Any(ur => ur.Value == Role.Admin))
        {
            await _unitOfWork.Macros.Delete(macroId);
        }
        else
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (macro.CreatorId != currentUserId) return Forbid("You are not authorized to delete this macro.");
            await _unitOfWork.Macros.Delete(macroId);
        }
        await _unitOfWork.Save();

        return NoContent();
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] string searchRequest)
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
}
