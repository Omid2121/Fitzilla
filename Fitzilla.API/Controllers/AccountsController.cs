using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Constants;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AccountsController(IMapper mapper, UserManager<User> userManager, IAuthManager authManager, IConfiguration configuration) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAuthManager _authManager = authManager;
    private readonly IConfiguration _configuration = configuration;

    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (userDTO.DateOfBirth < DateTime.Now.AddYears(-120) || userDTO.DateOfBirth > DateTime.Now.AddYears(-12))
        {
            return BadRequest("Invalid date of birth");
        }

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
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(userDTO.Email);

        if (user == null || !await _authManager.ValidateUser(userDTO)) return Unauthorized();

        var refreshToken = _authManager.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = _authManager.RefreshTokenExpiration();
        await _userManager.UpdateAsync(user);
        
        return Accepted(new AuthResponse
        {
            AccessToken = await _authManager.CreateAccessToken(user),
            AccessTokenExpiry = _authManager.AccessTokenExpiration(),
            RefreshToken = refreshToken,
            RefreshTokenExpiry = _authManager.RefreshTokenExpiration(),
        });
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest tokenRequest)
    {
        var principal = _authManager.GetPrincipalFromExpiredToken(tokenRequest.AccessToken);
        if (principal?.Identity?.Name == null) return Unauthorized();

        var user = await _userManager.FindByEmailAsync(principal.Identity.Name);

        if (user == null || user.RefreshToken != tokenRequest.RefreshToken || user.RefreshTokenExpiry < DateTimeOffset.UtcNow)
            return Unauthorized();

        return Accepted(new AuthResponse
        {
            AccessToken = await _authManager.CreateAccessToken(user),
            AccessTokenExpiry = _authManager.AccessTokenExpiration(),
            RefreshToken = user.RefreshToken,
            RefreshTokenExpiry = _authManager.RefreshTokenExpiration()
        });
    }

    [Authorize(Roles = "Admin, Consumer")]
    [HttpDelete("revoke-token")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RevokeRefreshToken()
    {
        var email = User.Identity?.Name;
        if (string.IsNullOrEmpty(email)) return Unauthorized();

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return Unauthorized();

        user.RefreshToken = null;

        await _userManager.UpdateAsync(user);

        return NoContent();
    }

    [Authorize(Roles = "Admin, Consumer")]
    [HttpGet("account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAccount()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (currentUserId == null) return BadRequest();

        var user = await _userManager.FindByIdAsync(currentUserId);

        if (user == null) return NotFound();
        var result = _mapper.Map<UserDTO>(user);

        return Ok(result);
    }

    [Authorize(Roles = "Admin, Consumer")]
    [HttpPut("update/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

    [Authorize(Roles = "Admin, Consumer")]
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("promote/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PromoteUser(string userId, [FromBody] List<string> roles)
    {
        if (!ModelState.IsValid || string.IsNullOrEmpty(userId)) return BadRequest(ModelState);

        if (roles.Count == 0 || roles == null) return BadRequest("No roles provided");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound("Account does not exist");

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                ModelState.AddModelError(role, "Role does not exist");
                return BadRequest(ModelState);
            }
        }
        var result = await _userManager.AddToRolesAsync(user, roles);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest("Promotion attempt failed");
        }

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("demote/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DemoteUser(string userId, [FromBody] List<string> roles)
    {
        if (!ModelState.IsValid || string.IsNullOrEmpty(userId)) return BadRequest(ModelState);

        if (roles.Count == 0 || roles == null) return BadRequest("No roles provided");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound("Account does not exist");

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                ModelState.AddModelError(role, "Role does not exist");
                return BadRequest(ModelState);
            }
        }
        var result = await _userManager.RemoveFromRolesAsync(user, roles);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest("Demotion attempt failed");
        }

        return NoContent();
    }
}