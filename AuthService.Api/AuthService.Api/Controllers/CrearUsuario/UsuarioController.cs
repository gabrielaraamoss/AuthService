using AuthService.Application.interfaces.Usuario;
using AuthService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers.CrearUsuario;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _usuario;
    public UsuarioController(IUsuario usuario)
    {
        _usuario = usuario;
    }
    [HttpPost]
    [Route("agregar")]
    public async Task<IActionResult> Agregar([FromBody] UsuarioRequest usuario)
    {
        var result = await _usuario.AgregarUser(usuario);
        if (!result)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}