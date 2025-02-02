using AuthService.Domain.Dto.Auth;

namespace AuthService.Application.interfaces.Auth;

public interface IAuth
{
    Task<AuthResponse> AutenticacionLogin(AuthRequest request);
}