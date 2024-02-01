using WebApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
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
        [Required]
        public double? Price { get; set; }
    }
}
