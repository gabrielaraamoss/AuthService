using AuthService.Application.interfaces.Auth;
using AuthService.Domain.Dto.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuth _iAuth;
    public AuthController(IAuth íAuth)
    {
        _iAuth = íAuth;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest login)
    {
        var result = await _iAuth.AutenticacionLogin(login);
        if (result == null)
        {
            return Unauthorized(result);
        }
        return Ok(result);
    }
}