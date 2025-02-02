using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AuthService.Application.exceptions;
using AuthService.Application.interfaces.Auth;
using AuthService.Domain.Dto.Auth;
using AuthService.Infraestructure.Models;
using AuthService.Infraestructure.utils;

namespace AuthService.Infraestructure.RepositoryAtuh;

public class AuthRepository : IAuth
{
    private readonly InventarioContext _context;

    public AuthRepository(InventarioContext context)
    {
        _context = context;
    }

    public async Task<AuthResponse> AutenticacionLogin(AuthRequest request)
    {
        try
        {
            var validateUser = await _context.Usuarios.Where(x => x.Usuario1 == request.userName).FirstOrDefaultAsync();
            if (validateUser != null)
            {
                string newHashedPassword = Encrypt.HashPassword(request.password.Trim(), validateUser.Salt ?? "");

                if (validateUser.Password.Trim() == newHashedPassword)
                {
                    var token = GenerateToken.CreateToken(validateUser.IdUsuario.ToString());
                    return new AuthResponse
                    {
                        Resultado = true,
                        Token = token,
                        Messaje = "Autenticación exitosa"
                    };
                }
            }

            throw new AutenticacionError("Nombre de usuario o contraseña incorrectos");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}