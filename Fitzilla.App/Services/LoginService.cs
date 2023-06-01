using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
