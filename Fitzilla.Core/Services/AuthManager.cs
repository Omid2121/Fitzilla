using Fitzilla.BLL.DTOs;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fitzilla.BLL.Services;

public class AuthManager(UserManager<User> userManager, IConfiguration configuration) : IAuthManager
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private User _user;

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOption(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        // Depending on where you store your key (Environment or appsettings.json)
        //var key = Environment.GetEnvironmentVariable("JwtSecretKey");
        var key = _configuration.GetSection("JwtSettings").GetSection("JwtSecretKey").Value;
        
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim(ClaimTypes.GivenName, _user.FirstName),
            new Claim(ClaimTypes.Surname, _user.LastName),
            new Claim(ClaimTypes.Email, _user.Email)
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
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var expiration = DateTimeOffset.Now.AddMinutes(
            Convert.ToDouble(jwtSettings.GetSection("JwtLifetime").Value));

        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetSection("JwtValidIssuer").Value,
            audience: jwtSettings.GetSection("JwtValidAudience").Value,
            claims: claims,
            expires: expiration.UtcDateTime,
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

    public async Task<AuthResponse> VerifyRefreshToken(AuthResponse tokenRequest)
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
                return new AuthResponse
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

    public void RevokeRefreshToken(string refreshToken, string email)
    {

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
