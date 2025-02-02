namespace AuthService.Domain.Dto.Auth;

public class AuthResponse
{
    public string Token { get; set; }
    public bool Resultado { get; set; }
    public string Messaje { get; set; }
}