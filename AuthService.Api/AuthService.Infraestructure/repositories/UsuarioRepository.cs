using AutoMapper;
using AuthService.Application.interfaces.Usuario;
using AuthService.Domain.Models;
using AuthService.Infraestructure.Models;
using AuthService.Infraestructure.utils;
using Microsoft.EntityFrameworkCore;
using Usuarios = AuthService.Infraestructure.Models.Usuarios;


namespace AuthService.Infraestructure.repositories;

public class UsuarioRepository : IUsuario
{
    private readonly InventarioContext _contextApi;
    private readonly IMapper _mapper;

    public UsuarioRepository(InventarioContext contextApi, IMapper mapper)
    {
        _contextApi = contextApi;
        _mapper = mapper;
    }

    public async Task<bool> AgregarUser(UsuarioRequest usuario)
    {
        try
        {
            var existe = await _contextApi.Usuarios.FirstOrDefaultAsync(x => x.Usuario1 == usuario.Usuario);
            if (existe != null)
            {
                return false;
            }

            var salt = Encrypt.GenerateSalt();
            var nuevoUsuario = new Usuarios
            {
                IdUsuario = new Guid(), 
                Nombres = usuario.Nombres, 
                Usuario1 = usuario.Usuario, 
                Salt = salt, 
                Password = Encrypt.HashPassword(usuario.Password ?? "", salt) 
            };

            _contextApi.Usuarios.Add(nuevoUsuario);
            await _contextApi.SaveChangesAsync(); 

            return true; 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}