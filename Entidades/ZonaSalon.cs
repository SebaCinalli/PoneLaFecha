using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ZonaSalon
    {
        [Key]
        public int IdZonaSalon { get; set; }
   
    [Required]
        public int IdZona { get; set; }
        
    [Required]
    public int IdSalon { get; set; }
        
        // Navegación
    [ForeignKey("IdZona")]
        public Zona Zona { get; set; }
        
        [ForeignKey("IdSalon")]
        public Salon Salon { get; set; }
    }
}
