using Sponsorship.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sponsorship.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DropdownController : ControllerBase
{
    private readonly IDropdownService _dropdownService;

    public DropdownController(IDropdownService dropdownService)
    {
        _dropdownService = dropdownService;
    }

    // GET: api/dropdown/departments
    [HttpGet("departments")]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _dropdownService.GetDepartmentsAsync();
        return Ok(departments);
    }

    // GET: api/dropdown/sponsorshiptypes
    [HttpGet("sponsorshiptypes")]
    public async Task<IActionResult> GetSponsorshipTypes()
    {
        var sponsorshipTypes = await _dropdownService.GetSponsorshipTypesAsync();
        return Ok(sponsorshipTypes);
    }

}