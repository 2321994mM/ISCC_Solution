using ISCC.Application.DTOs;
using ISCC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISCC.Api.Android.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _authService.AuthenticateAsync(request.Username, request.Password, cancellationToken);
        if (user == null)
            return Unauthorized(new { Message = "Invalid username or password" });

        var session = await _authService.CreateSessionAsync(user, cancellationToken);

        var response = new LoginResponse(
            user.Id,
            user.Username,
            user.FullName,
            user.Role.ToString(),
            session.SessionToken
        );

        return Ok(response);
    }
}
