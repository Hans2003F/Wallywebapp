using System.ComponentModel.DataAnnotations;
using WallyAndynaswebApp.Dtos;

namespace WallyAndynaswebApp.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Cuenta { get; set; }
        [Required]
        public string? Contraseña { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public RolEnum Rol { get; set; }
    }
}
