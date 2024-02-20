using Fitzilla.BLL.DTOs;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Fitzilla.BLL.Services;

public class AuthManager(UserManager<User> userManager, IConfiguration configuration) : IAuthManager
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private User _user;

    public async Task<string> CreateAccessToken()
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
            new(ClaimTypes.NameIdentifier, _user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, _user.Email),
            new(ClaimTypes.Name, _user.UserName),
            new(ClaimTypes.GivenName, _user.FirstName),
            new(ClaimTypes.Surname, _user.LastName),
            new(ClaimTypes.Email, _user.Email)
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
        var expiration = DateTimeOffset.Now.AddHours(
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
        _user = await _userManager.FindByNameAsync(userDTO.Email) ?? throw new Exception("User not found");
        return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password));
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];

        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        //var key = Environment.GetEnvironmentVariable("JwtSecretKey") ?? throw new Exception("Secret key was not configured.");
        var key = jwtSettings.GetSection("JwtSecretKey").Value ?? throw new Exception("Secret key was not configured.");

        var validation = new TokenValidationParameters
        {
            ValidateIssuer = true,              
            ValidateLifetime = false,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = jwtSettings.GetSection("JwtValidAudience").Value,
            ValidIssuer = jwtSettings.GetSection("JwtValidIssuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
    }

    public async Task<string> GetUserRoleById(string userId)
    {
        _user = await _userManager.FindByIdAsync(userId) ?? throw new Exception("User not found");
        return _userManager.GetRolesAsync(_user).Result.FirstOrDefault() ?? throw new Exception("Role not found");
    }

    public async Task<UserDTO> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
    {
        _user = await _userManager.GetUserAsync(claimsPrincipal) ?? throw new Exception("User not found");

        return new UserDTO
        {
            Id = _user.Id
        };
    }
}
