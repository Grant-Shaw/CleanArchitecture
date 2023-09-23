using ExampleApi.Application.Services.Authentication;
using ExampleApi.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        return Ok(registerResult);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authService.Login(request.Email, request.Password);
        return Ok(loginResult);
    }

}