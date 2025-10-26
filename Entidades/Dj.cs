using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Dj
    {
        [Key]
        public int IdDj { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string NombreArtistico { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;
    
        [Required]
        public decimal MontoDj { get; set; }
        
        // Navegación
        public ICollection<ZonaDJ> ZonaDJs { get; set; } = new List<ZonaDJ>();
        public ICollection<DjSolicitud> DjSolicitudes { get; set; } = new List<DjSolicitud>();
    }
}