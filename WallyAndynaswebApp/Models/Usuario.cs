using WallyAndynaswebApp.Dtos;

namespace WallyAndynaswebApp.Models
{
    public class Usuario
    {
        public string? Cuenta { get; set; }
        public string? Contraseña { get; set; }
        public string? NombreCompleto { get; set; }
        public RolEnum Rol { get; set; }
    }
}
