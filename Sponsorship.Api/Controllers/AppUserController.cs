using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sponsorship.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _service;

        public AppUserController(IAppUserService service)
        {
            _service = service;
        }

        // GET: api/appusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserReadDto>>> GetAll()
        {
            var result = await _service.GetAllAppUsersAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/appusers/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AppUserReadDto>> GetById(Guid id)
        {
            var result = await _service.GetAppUserByIdAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/appusers
        [HttpPost]
        public async Task<ActionResult<AppUserReadDto>> Create([FromBody] AppUserCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.AddAppUserAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT: api/appusers/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AppUserReadDto>> Update(Guid id, [FromBody] AppUserUpdateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.UpdateAppUserAsync(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE: api/appusers/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAppUserAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
