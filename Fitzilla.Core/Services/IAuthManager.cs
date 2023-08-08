using Fitzilla.Core.DTOs;
using Fitzilla.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest tokenRequest);
        Task<string> GetUserRoleById(string userId);
        Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
    }
}
