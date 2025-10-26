using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Gastronomico
    {
        [Key]
        public int IdGastro { get; set; }
        
        [Required(ErrorMessage = "El tipo de comida es requerido")]
        [StringLength(100, ErrorMessage = "El tipo de comida no puede exceder los 100 caracteres")]
        public string TipoComida { get; set; }
        
        [StringLength(255, ErrorMessage = "La ruta de la foto no puede exceder los 255 caracteres")]
        public string? Foto { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal MontoG { get; set; }
        
        // Navegación
        public ICollection<ZonaGastro> ZonaGastros { get; set; } = new List<ZonaGastro>();
        public ICollection<GastroSolicitud> GastroSolicitudes { get; set; } = new List<GastroSolicitud>();
    }
}