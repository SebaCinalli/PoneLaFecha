using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class SalonSolicitud
    {
        [Key]
        public int IdSalonSolicitud { get; set; }
        
  [Required]
        public int IdSalon { get; set; }
        
  [Required]
        public int IdSolicitud { get; set; }
        
        // Navegación
        [ForeignKey("IdSalon")]
    public Salon Salon { get; set; }
        
        [ForeignKey("IdSolicitud")]
   public Solicitud Solicitud { get; set; }
  }
}
