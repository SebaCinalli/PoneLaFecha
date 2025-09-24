using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Salon
    {
        [Key]
        public int IdSalon { get; set; }
        public string NombreSalon { get; set; }
        public string Estado { get; set; }
        public decimal MontoSalon { get; set; }
    }
}
