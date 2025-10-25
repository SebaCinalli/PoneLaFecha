using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ZonaBarra
    {
        [Key]
        public int IdZonaBarra { get; set; }
        
        [Required]
     public int IdZona { get; set; }
        
        [Required]
        public int IdBarra { get; set; }
    
        // Navegación
   [ForeignKey("IdZona")]
        public Zona Zona { get; set; }
        
        [ForeignKey("IdBarra")]
     public Barra Barra { get; set; }
  }
}
