namespace AuthService.Api.Models1;

public partial class Usuarios
{
    public Guid IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Usuario1 { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }
}
