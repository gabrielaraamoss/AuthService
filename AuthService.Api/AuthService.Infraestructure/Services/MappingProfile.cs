using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AuthService.Infraestructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioRequest, Usuarios>()
            .ForMember(u => u.IdUsuario, x => x.MapFrom(x => Guid.NewGuid().ToString()));
    }
}