using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.Models;
using System.Security.Claims;

namespace Fitzilla.BLL.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoginUserDTO userDTO);
    Task<string> CreateAccessToken();
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    Task<string> GetUserRoleById(string userId);
    Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
}
