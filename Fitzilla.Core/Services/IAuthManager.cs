using Fitzilla.DAL.DTOs;
using Fitzilla.DAL.Models;
using System.Security.Claims;

namespace Fitzilla.BLL.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
        Task<string> CreateRefreshToken();
        Task<AuthResponse> VerifyRefreshToken(AuthResponse tokenRequest);
        Task<string> GetUserRoleById(string userId);
        Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
    }
}
