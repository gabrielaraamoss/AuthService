

namespace AuthService.Domain.Models
{
    public class UsuarioRequest
    {
        public Guid? Idusuario { get; set; }

        public string? Nombres { get; set; }

        public string? Usuario { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }
    }
}