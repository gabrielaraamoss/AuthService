namespace AuthService.Domain.Models;

public partial class Usuarios
{
    public Guid IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Usuario { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }
}