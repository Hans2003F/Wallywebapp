using System.ComponentModel.DataAnnotations;

namespace WallyAndynaswebApp.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public int CI { get; set; }
        public int Celular { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
