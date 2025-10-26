using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Barra
    {
        [Key]
        public int IdBarra { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string TipoBebida { get; set; } = string.Empty;
        public decimal PrecioPorHora { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        
        // Navegación
        public ICollection<ZonaBarra> ZonaBarras { get; set; } = new List<ZonaBarra>();
        public ICollection<BarraSolicitud> BarraSolicitudes { get; set; } = new List<BarraSolicitud>();
    }
}