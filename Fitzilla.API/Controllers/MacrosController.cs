using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class MacrosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MacroManager _macroManager;
    private readonly UserManager<User> _userManager;

    public MacrosController(IUnitOfWork unitOfWork, IMapper mapper, MacroManager macroManager, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _macroManager = macroManager;
        _userManager = userManager;
    }

    [Authorize(Roles = "Admin,Consumer")]
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

    [Authorize(Roles = "Admin,Consumer")]
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

    [Authorize(Roles = "Admin,Consumer")]
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

        macro = _macroManager.CalculateMacros(macro, currentUser);
        if (macro is null) return BadRequest("Invalid payload.");
        
        await _unitOfWork.Macros.Insert(macro);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetMacro", new { macroId = macro.Id }, macro);
    }

    [Authorize(Roles = "Admin,Consumer")]
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
            macro = _macroManager.CalculateMacros(macro, currentUser);
            if (macro is null) return BadRequest("Invalid payload.");
            _unitOfWork.Macros.Update(macro);
        }
        else
        {
            //var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (macro.CreatorId != currentUser.Id) return Forbid("You are not authorized to update this macro.");
            macro = _macroManager.CalculateMacros(macro, currentUser);
            if (macro is null) return BadRequest("Invalid payload.");
            _unitOfWork.Macros.Update(macro);
        }
        await _unitOfWork.Save();
        
        return NoContent();
    }

    [Authorize(Roles = "Admin,Consumer")]
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

    [Authorize(Roles = "Admin,Consumer")]
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
