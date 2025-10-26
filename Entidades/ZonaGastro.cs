using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ZonaGastro
    {
   [Key]
        public int IdZonaGastro { get; set; }
        
        [Required]
        public int IdZona { get; set; }
        
        [Required]
        public int IdGastro { get; set; }
        
        // Navegación
 [ForeignKey("IdZona")]
     public Zona Zona { get; set; }
    
        [ForeignKey("IdGastro")]
public Gastronomico Gastronomico { get; set; }
    }
}
