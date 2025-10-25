using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class GastroSolicitud
    {
[Key]
        public int IdGastroSolicitud { get; set; }

    [Required]
        public int IdGastro { get; set; }
     
        [Required]
        public int IdSolicitud { get; set; }
        
        // Navegación
        [ForeignKey("IdGastro")]
        public Gastronomico Gastronomico { get; set; }
        
        [ForeignKey("IdSolicitud")]
        public Solicitud Solicitud { get; set; }
}
}
