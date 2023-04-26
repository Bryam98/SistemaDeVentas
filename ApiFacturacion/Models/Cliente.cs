using System.ComponentModel.DataAnnotations;

namespace ApiFacturacion.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name ="ClienteId")]
        public int Id{ get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cedula { get; set; }
        public int Edad { get; set; }
        public string? telefono { get; set; }
        public string? Correo { get; set; }

    }
}
