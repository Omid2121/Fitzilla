using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AccountsController(IMapper mapper, UserManager<User> userManager, IAuthManager authManager) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IAuthManager _authManager = authManager;

    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = _mapper.Map<User>(userDTO);
        user.UserName = userDTO.Email;
        var result = await _userManager.CreateAsync(user, userDTO.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        await _userManager.AddToRoleAsync(user, Role.Consumer);

        return Accepted();
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await _authManager.ValidateUser(userDTO)) return Unauthorized();

        return Accepted(new AuthResponse
        {
            Token = await _authManager.CreateToken(),
            RefreshToken = await _authManager.CreateRefreshToken()
        });
    }

    [HttpGet("account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccount()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return BadRequest();

        var user = await _userManager.FindByIdAsync(currentUserId);

        if (user == null) return NotFound();
        var result = _mapper.Map<UserDTO>(user);

        return Ok(result);
    }

    //TODO: Make sure it works
    [Authorize(Roles = "Admin, Consumer")]
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("YourAuthenticationScheme");
        return Ok();
    }


    [HttpPost]
    [Route("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RefreshToken([FromBody] AuthResponse tokenRequest)
    {
        var tokenRequestResult = await _authManager.VerifyRefreshToken(tokenRequest);

        if (tokenRequestResult is null) return Unauthorized();

        return Ok(tokenRequestResult);
    }

    [HttpPut("update/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAccount(string userId, [FromBody] UpdateUserDTO userDTO)
    {
        if (!ModelState.IsValid || string.IsNullOrEmpty(userId)) return BadRequest(ModelState);

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound("Account does not exist");

        _mapper.Map(userDTO, user);
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest("Account Update attempt failed");
        }

        return NoContent();
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAccount([FromBody] DeleteUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(userDTO.Email);
        if (user == null) return BadRequest("Account does not exist");

        if (!await _authManager.ValidateUser(userDTO)) return Unauthorized();

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest("Account Delete attempt failed");
        }

        return NoContent();
    }
}
