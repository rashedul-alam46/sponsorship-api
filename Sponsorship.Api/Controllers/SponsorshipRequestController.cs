using Sponsorship.Application.DTOs;
using Sponsorship.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sponsorship.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class SponsorshipRequestController : ControllerBase
    {
        private readonly ISponsorshipRequestService _service;

        public SponsorshipRequestController(ISponsorshipRequestService service)
        {
            _service = service;
        }

        // GET: api/sponsorshiprequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SponsorshipRequestReadDto>>> GetAll()
        {
            var result = await _service.GetSponsorshipRequestsAsync();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/sponsorshiprequests/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SponsorshipRequestReadDto>> GetById(Guid id)
        {
            var result = await _service.GetSponsorshipRequestAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/sponsorshiprequests
        [HttpPost]
        public async Task<ActionResult<SponsorshipRequestReadDto>> Create([FromBody] SponsorshipRequestCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.AddSponsorshipRequestAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // PUT: api/sponsorshiprequests/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SponsorshipRequestReadDto>> Update(Guid id, [FromBody] SponsorshipRequestUpdateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.UpdateSponsorshipRequestAsync(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE: api/sponsorshiprequests/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteSponsorshipRequestAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
