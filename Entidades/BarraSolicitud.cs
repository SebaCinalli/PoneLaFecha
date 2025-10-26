using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class BarraSolicitud
    {
        [Key]
        public int IdBarraSolicitud { get; set; }
        
        [Required]
    public int IdBarra { get; set; }
 
        [Required]
        public int IdSolicitud { get; set; }
        
    // Navegación
        [ForeignKey("IdBarra")]
      public Barra Barra { get; set; }
        
[ForeignKey("IdSolicitud")]
        public Solicitud Solicitud { get; set; }
    }
}
