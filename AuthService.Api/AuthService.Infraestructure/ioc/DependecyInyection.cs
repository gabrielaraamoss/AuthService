using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AuthService.Application.interfaces.Auth;
using AuthService.Application.interfaces.Usuario;
using AuthService.Infraestructure.Models;
using AuthService.Infraestructure.repositories;
using AuthService.Infraestructure.RepositoryAtuh;


namespace AuthService.Infraestructure.ioc
{
    public static class DependecyInyection
    {
        public static IServiceCollection AddInfractructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IAuth, AuthRepository>();
            services.AddScoped<IUsuario, UsuarioRepository>();

            services.AddDbContext<InventarioContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(MappingProfile));
            
            return services;
        }
    }
}