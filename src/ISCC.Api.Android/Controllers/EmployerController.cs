using ISCC.Application.DTOs;
using ISCC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployerController : ControllerBase
{
    private readonly IEmployerService _employerService;

    public EmployerController(IEmployerService employerService)
    {
        _employerService = employerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var employers = await _employerService.GetAllEmployersAsync(cancellationToken);
        return Ok(employers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var employer = await _employerService.GetEmployerByIdAsync(id, cancellationToken);
        if (employer == null)
            return NotFound();

        return Ok(employer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployerRequest request, CancellationToken cancellationToken)
    {
        // TODO: Use AutoMapper to map DTO to entity
        return Ok();
    }
}
