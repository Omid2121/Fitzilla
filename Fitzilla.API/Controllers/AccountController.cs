using AutoMapper;
using Fitzilla.Core.DTOs;
using Fitzilla.Core.Models;
using Fitzilla.Core.Services;
using Fitzilla.Data.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthManager _authManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, IAuthManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Accepted();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _authManager.ValidateUser(userDTO)) return Unauthorized();

            return Accepted(new TokenRequest
            {
                Token = await _authManager.CreateToken(),
                RefreshToken = await _authManager.CreateRefreshToken()
            });
        }

        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            var tokenRequestResult = await _authManager.VerifyRefreshToken(tokenRequest);

            if (tokenRequestResult is null) return Unauthorized();

            return Ok(tokenRequestResult);
        }

        [HttpPatch("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAccount(string id, [FromBody] JsonPatchDocument<UpdateUserDTO> patchDoc)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id)) return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return BadRequest("Account does not exist");

            var userDTO = _mapper.Map<UpdateUserDTO>(user);
            patchDoc.ApplyTo(userDTO, ModelState);

            if (!TryValidateModel(userDTO)) return BadRequest(ModelState);

            _mapper.Map(userDTO, user);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest("Account Update attempt failed");
            }

            return NoContent();
        }

        //[HttpPut("update/{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> UpdateAccount(string id, [FromBody] UpdateUserDTO userDTO)
        //{
        //    if (!ModelState.IsValid || string.IsNullOrEmpty(id)) return BadRequest(ModelState);

        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user == null) return BadRequest("Account does not exist");

        //    _mapper.Map(userDTO, user);
        //    var result = await _userManager.UpdateAsync(user);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(error.Code, error.Description);
        //        }
        //        return BadRequest("Account Update attempt failed");
        //    }

        //    return NoContent();
        //}

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteUserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user == null) return BadRequest("Account does not exist");

            if (!await _authManager.ValidateUser(userDTO)) return Unauthorized();

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest("Account Delete attempt failed");
            }

            return NoContent();
        }
    }
}
