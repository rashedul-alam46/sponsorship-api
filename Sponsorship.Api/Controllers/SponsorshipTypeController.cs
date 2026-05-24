using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sponsorship.Api.Controllers
{
    [ApiController]
    [Route("api/sponsorshiptypes")]
    public class SponsorshipTypeController : ControllerBase
    {
        private readonly ISponsorshipTypeService _service;

        public SponsorshipTypeController(ISponsorshipTypeService service)
        {
            _service = service;
        }

        // GET: api/sponsorshiptypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SponsorshipTypeReadDto>>> GetAll()
        {
            var result = await _service.GetSponsorshipTypesAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/sponsorshiptypes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SponsorshipTypeReadDto>> GetById(string id)
        {
            var result = await _service.GetSponsorshipTypeAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/sponsorshiptypes
        [HttpPost]
        public async Task<ActionResult<SponsorshipTypeReadDto>> Create([FromBody] SponsorshipTypeCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.AddSponsorshipTypeAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT: api/sponsorshiptypes/{id}
        [HttpPut("{id}")]

        public async Task<ActionResult<SponsorshipTypeReadDto>> Update(string id, [FromBody] SponsorshipTypeUpdateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.UpdateSponsorshipTypeAsync(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE: api/sponsorshiptypes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _service.DeleteSponsorshipTypeAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
