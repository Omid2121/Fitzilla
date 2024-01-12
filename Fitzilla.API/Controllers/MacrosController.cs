using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.BLL.Services;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fitzilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class MacrosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public MacrosController(IUnitOfWork unitOfWork, IMapper mapper, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authManager = authManager;
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMacros(RequestParams requestParams)
        {
            IEnumerable<Macro> macros = await _unitOfWork.Macros.GetPagedList(requestParams);
            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            if (userRole != "Admin")
            {
                macros = macros.Where(m => m.CreatorId == currentUser.Id);
            }
            var result = _mapper.Map<IList<MacroDTO>>(macros);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("{id}", Name = "GetMacro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMacro(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(id));

            if (!await IsAuthorized(macro.CreatorId)) return Forbid();

            var result = _mapper.Map<MacroDTO>(macro);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMacro([FromBody] CreateMacroDTO macroDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var currentUser = await _authManager.GetCurrentUser(User);
            if (macroDTO.CreatorId != currentUser.Id) return BadRequest("Ids doesn't match");

            var macro = _mapper.Map<Macro>(macroDTO);
            await _unitOfWork.Macros.Insert(macro);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetMacro", new { id = macro.Id }, macro);
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateMacro(Guid id, [FromBody] UpdateMacroDTO macroDTO)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(id));
            if (macro is null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(macro.CreatorId)) return Forbid();

            _mapper.Map(macroDTO, macro);
            _unitOfWork.Macros.Update(macro);
            await _unitOfWork.Save();
            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteMacro(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var macro = await _unitOfWork.Macros.Get(m => m.Id.Equals(id));
            if (macro is null) return BadRequest("Submitted data is invalid.");

            if (!await IsAuthorized(macro.CreatorId)) return Forbid();

            await _unitOfWork.Macros.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }

        [Authorize(Roles = "Admin,Consumer")]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery] string searchRequest)
        {
            if (string.IsNullOrEmpty(searchRequest)) return BadRequest("Submitted data is invalid.");

            var currentUser = await _authManager.GetCurrentUser(User);
            var userRole = await _authManager.GetUserRoleById(currentUser.Id);

            IEnumerable<Macro> macros = await _unitOfWork.Macros
                .Search(macro => macro.Title.ToLower()
                .Contains(searchRequest.ToLower()));

            if (userRole != "Admin")
            {
                macros = macros.Where(m => m.CreatorId == currentUser.Id);
            }

            var result = _mapper.Map<IList<MacroDTO>>(macros);

            return Ok(result);
        }

    }
}
