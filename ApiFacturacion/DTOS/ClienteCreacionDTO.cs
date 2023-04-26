using System.ComponentModel.DataAnnotations;

namespace ApiFacturacion.DTOS
{
    public class ClienteCreacionDTO
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="Campo requerido")]
        public string? Nombres { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Campo requerido")]
        public string? Apellidos { get; set; }
        [StringLength(16)]
        [Required(ErrorMessage = "Campo requerido")]
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Phone]
        public string? telefono { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Campo requerido")]
        public string? Correo { get; set; }
    }
}
