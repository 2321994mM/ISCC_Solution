using ISCC.Application.DTOs;
using ISCC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspectionController : ControllerBase
{
    private readonly IInspectionService _inspectionService;

    public InspectionController(IInspectionService inspectionService)
    {
        _inspectionService = inspectionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var inspection = await _inspectionService.GetInspectionByIdAsync(id, cancellationToken);
        if (inspection == null)
            return NotFound();

        return Ok(inspection);
    }

    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetByClient(int clientId, CancellationToken cancellationToken)
    {
        var inspections = await _inspectionService.GetInspectionsByClientIdAsync(clientId, cancellationToken);
        return Ok(inspections);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInspectionRequest request, CancellationToken cancellationToken)
    {
        // TODO: Use AutoMapper to map DTO to entity
        return Ok();
    }
}
