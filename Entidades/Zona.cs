using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Zona
 {
 [Key]
        public int IdZona { get; set; }
   
        [Required]
      [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        // Navegación
      public ICollection<ZonaSalon> ZonaSalones { get; set; } = new List<ZonaSalon>();
        public ICollection<ZonaBarra> ZonaBarras { get; set; } = new List<ZonaBarra>();
        public ICollection<ZonaGastro> ZonaGastros { get; set; } = new List<ZonaGastro>();
        public ICollection<ZonaDJ> ZonaDJs { get; set; } = new List<ZonaDJ>();
    }
}
