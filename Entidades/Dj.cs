using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Dj
    {
        [Key]
        public int IdDj { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string NombreArtistico { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;
        
        [Required]
        public decimal MontoDj { get; set; }
        
        [MaxLength(255)]
        public string? Foto { get; set; }
    }
}