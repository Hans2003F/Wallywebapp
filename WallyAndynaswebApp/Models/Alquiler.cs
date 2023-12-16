using System.ComponentModel.DataAnnotations;
using WallyAndynaswebApp.Dtos;
namespace WallyAndynaswebApp.Models
{
    public class Alquiler
    {
        public int Id { get; set; }
        [Required]
        public int  NumCancha { get; set; }
        [Required]
        public string? Cliente { get; set;}
        [Required]
        public int CedIden { get; set; }
        [Required]
        public int Celular { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int Horas { get; set; }
        [Required]
        public DateTime Desde { get; set; }
        [Required]
        public DateTime Hasta { get; set;}
        [Required]
        public int Costo { get; set; }
        [Required]
        public RolEstado Estado { get; set;}


        //foreing keys
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int CanchaId { get; set; }
        public Cancha? Cancha { get; set; }
    }
}
