using Fitzilla.Core.DTOs;
using System.Net.Http.Json;

namespace Fitzilla.App.Services
{
    public class LoginService : ILoginService
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly string AuthURL = $"https://localhost:44305/api/account";

        public async Task<LoginResponseDTO> LoginAsync(LoginUserDTO loginUserDTO)
        {
            HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync($"{AuthURL}/login", loginUserDTO);
            if (!responseMessage.IsSuccessStatusCode) return null;

            return await responseMessage.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<LoginResponseDTO> RegisterAsync(UserDTO userDTO)
        {
            HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync($"{AuthURL}/register", userDTO);
            if (!responseMessage.IsSuccessStatusCode) return null;

            return await responseMessage.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }
    }
}
