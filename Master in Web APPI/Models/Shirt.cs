using Master_in_Web_APPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace Master_in_Web_APPI.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Ensure_ShirtSizing]
        public int? Size { get; set; }
        public string? Gender { get; set; }
        public double? Price { get; set; }
    }
}
