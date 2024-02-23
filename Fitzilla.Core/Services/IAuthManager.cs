using Fitzilla.BLL.DTOs;
using Fitzilla.Models.Data;
using System.Security.Claims;

namespace Fitzilla.BLL.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoginUserDTO userDTO);
    Task<string> CreateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    Task<string> GetUserRoleById(string userId);
    DateTimeOffset AccessTokenExpiration();
    DateTimeOffset RefreshTokenExpiration();
}
