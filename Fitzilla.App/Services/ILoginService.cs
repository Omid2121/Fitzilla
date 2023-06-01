using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDTO> LoginAsync(LoginUserDTO userDTO);
        Task<LoginResponseDTO> RegisterAsync(UserDTO userDTO);
    }
}
