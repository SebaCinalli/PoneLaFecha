using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ZonaDJ
    {
        [Key]
        public int IdZonaDJ { get; set; }
        
  [Required]
   public int IdZona { get; set; }
      
    [Required]
  public int IdDj { get; set; }
        
        // Navegación
     [ForeignKey("IdZona")]
  public Zona Zona { get; set; }
        
        [ForeignKey("IdDj")]
        public Dj Dj { get; set; }
    }
}
