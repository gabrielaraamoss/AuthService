
using AuthService.Domain.Models;

namespace AuthService.Application.interfaces.Usuario;

public interface IUsuario
{
    Task<bool> AgregarUser(UsuarioRequest usuario);
}