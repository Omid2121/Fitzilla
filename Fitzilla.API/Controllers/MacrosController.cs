using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.DAL.Repository;
using Fitzilla.Models;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data;
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

        //// User's BMR (Basal Metabolic Rate)
        //int age = DateTime.Now.Year - currentUser.DateOfBirth.Year;
        //if (currentUser.Gender == Gender.Male)
        //{
        //    macro.Calorie = (10 * currentUser.Weight) + (6.25 * currentUser.Height) - (5 * age) + 5;
        //}
        //else
        //{
        //    macro.Calorie = (10 * currentUser.Weight) + (6.25 * currentUser.Height) - (5 * age) - 161;
        //}

        //// User's TDEE (Total Daily Energy Expenditure)
        //switch (macro.ActivityLevel)
        //{
        //    case ActivityLevel.Sedentary:
        //        macro.Calorie *= 1.2;
        //        break;
        //    case ActivityLevel.LightlyActive:
        //        macro.Calorie *= 1.375;
        //        break;
        //    case ActivityLevel.ModeratelyActive:
        //        macro.Calorie *= 1.55;
        //        break;
        //    case ActivityLevel.VigorouslyActive:
        //        macro.Calorie *= 1.725;
        //        break;
        //    case ActivityLevel.VeryActive:
        //        macro.Calorie *= 1.9;
        //        break;
        //    default:
        //        break;
        //}

        //// Find user's goal type (Cutting, Maintenance, Bulking)
        //switch (macro.GoalType)
        //{
        //    case GoalType.MildWeightLoss:
        //        macro.Calorie -= 250;
        //        break;
        //    case GoalType.WeightLoss:
        //        macro.Calorie -= 500;
        //        break;
        //    case GoalType.ExtremeWeightLoss:
        //        macro.Calorie -= 1000;
        //        break;
        //    case GoalType.Maintenance:
        //        break;
        //    case GoalType.MildWeightGain:
        //        macro.Calorie += 250;
        //        break;
        //    case GoalType.WeightGain:
        //        macro.Calorie += 500;
        //        break;
        //    case GoalType.ExtremeWeightGain:
        //        macro.Calorie += 1000;
        //        break;
        //    default:
        //        break;
        //}

        //// User's macros (Protein, Carbs, Fat)
        //if (macro.ProteinPercentage + macro.CarbohydratePercentage + macro.FatPercentage != 100) return BadRequest("Macros must add up to 100%.");

        //macro.ProteinAmount = macro.Calorie * (macro.ProteinPercentage / 100) / 4;
        //macro.CarbohydrateAmount = macro.Calorie * (macro.CarbohydratePercentage / 100) / 4;
        //macro.FatAmount = macro.Calorie * (macro.FatPercentage / 100) / 9;

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
