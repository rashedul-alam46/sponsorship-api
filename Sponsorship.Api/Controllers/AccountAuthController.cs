
using Microsoft.AspNetCore.Mvc;
using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Services;

namespace Sponsorship.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AccountAuthController : ControllerBase
    {
        private readonly IAccountAuthService _service;

        public AccountAuthController(IAccountAuthService service)
        {
            _service = service;
        }

        // POST: api/accountauths/change-password
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.ChangePasswordAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        // POST: api/accountauths/sign-in
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.SignInAsync(dto);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        // POST: api/accountauths/sign-out
        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            var result = await _service.SignOutAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
