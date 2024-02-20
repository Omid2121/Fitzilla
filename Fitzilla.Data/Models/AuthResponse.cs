namespace Fitzilla.DAL.Models;

public class AuthResponse
{
    public string AccessToken { get; set; }
    public DateTimeOffset AccessTokenExpiry { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset RefreshTokenExpiry { get; set; }
}
