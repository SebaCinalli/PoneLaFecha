using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Solicitud
    {
 [Key]
        public int IdSolicitud { get; set; }
        
        [Required]
        public int IdCliente { get; set; }
  
        [Required]
        public DateTime FechaDesde { get; set; }
        
        [Required]
      public decimal MontoDJ { get; set; }
        
    [Required]
        public decimal MontoSalon { get; set; }
    
        [Required]
   public decimal MontoGastro { get; set; }
        
        [Required]
      public decimal MontoBarra { get; set; }
      
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Confirmada, Cancelada
        
        // Navegación
 public Cliente Cliente { get; set; }
        public ICollection<SalonSolicitud> SalonSolicitudes { get; set; } = new List<SalonSolicitud>();
        public ICollection<BarraSolicitud> BarraSolicitudes { get; set; } = new List<BarraSolicitud>();
public ICollection<GastroSolicitud> GastroSolicitudes { get; set; } = new List<GastroSolicitud>();
     public ICollection<DjSolicitud> DjSolicitudes { get; set; } = new List<DjSolicitud>();
    }
}
