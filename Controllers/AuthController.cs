using Microsoft.AspNetCore.Mvc;
using PhotoGalery.Models;
using PhotoGalery.Services;

namespace PhotoGalery.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        try
        {
            var token = await _authService.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);
            return Ok(new { Token = token });
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid username or password.");
        }
    }
}