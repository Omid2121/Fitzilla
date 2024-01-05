using Fitzilla.Core.DTOs;

namespace Fitzilla.App.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDTO> LoginAsync(LoginUserDTO userDTO);
        Task<LoginResponseDTO> RegisterAsync(UserDTO userDTO);
    }
}
