using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class DjSolicitud
    {
        [Key]
        public int IdDjSolicitud { get; set; }
        
        [Required]
        public int IdDj { get; set; }
  
        [Required]
        public int IdSolicitud { get; set; }
        
   // Navegación
        [ForeignKey("IdDj")]
        public Dj Dj { get; set; }
    
      [ForeignKey("IdSolicitud")]
 public Solicitud Solicitud { get; set; }
    }
}
