using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WallyAndynaswebApp.Models
{
    public class Canchas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumCancha { get; set; }
        [Required]
        public string? Imagen { get; set; } //almacenar la foto
        [Required]
        public string? Descripcion { get; set;}

        //solo de ayuda para cargar la foto
        [NotMapped] //para que no se mapee en la base de datos
        [Display(Name = "Cargar Foto")]
        public IFormFile? ImagenFile { get; set; } //cargar la imagen de la cancha
    }
}
