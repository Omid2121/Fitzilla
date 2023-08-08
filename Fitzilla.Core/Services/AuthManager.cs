using Fitzilla.Core.DTOs;
using Fitzilla.Core.Models;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fitzilla.Core.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOption(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOption(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(
                Convert.ToDouble(jwtSettings.GetSection("Lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                audience: jwtSettings.GetSection("Audience").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return token;
        }

        public async Task<bool> ValidateUser(LoginUserDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password));
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, "FitzillaApi", "RefreshToken");
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, "FitzillaApi", "RefreshToken");
            await _userManager.SetAuthenticationTokenAsync(_user, "FitzillaApi", "RefreshToken", newRefreshToken);

            return newRefreshToken;
        }

        public async Task<TokenRequest> VerifyRefreshToken(TokenRequest tokenRequest)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(tokenRequest.Token);
            var userName = tokenContent.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Name)?.Value;
            _user = await _userManager.FindByNameAsync(userName);

            try
            {
                var isValid = await _userManager.VerifyUserTokenAsync(_user, "FitzillaApi", "RefreshToken", tokenRequest.RefreshToken);
                if (isValid)
                {
                    return new TokenRequest
                    {
                        Token = await CreateToken(),
                        RefreshToken = await CreateRefreshToken()
                    };
                }
                await _userManager.UpdateSecurityStampAsync(_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<string> GetUserRoleById(string userId)
        {
            _user = await _userManager.FindByIdAsync(userId);
            return _userManager.GetRolesAsync(_user).Result.FirstOrDefault();
        }

        public async Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            _user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDTO
            {
                Id = _user.Id
            };
        }
    }
}
