using ISCC.Application.DTOs;
using ISCC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id, cancellationToken);
        if (payment == null)
            return NotFound();

        return Ok(payment);
    }

    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetByClient(int clientId, CancellationToken cancellationToken)
    {
        var payments = await _paymentService.GetPaymentsByClientIdAsync(clientId, cancellationToken);
        return Ok(payments);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        // TODO: Use AutoMapper to map DTO to entity
        return Ok();
    }
}
