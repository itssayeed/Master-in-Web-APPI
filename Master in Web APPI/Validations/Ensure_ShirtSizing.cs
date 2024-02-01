using Master_in_Web_APPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Master_in_Web_APPI.Validations
{
    public class Ensure_ShirtSizing : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;
            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("For mens size should be 8 and above");
                }
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 12)
                {
                    return new ValidationResult("for women size should be 12 and above");
                }
            }
            return ValidationResult.Success;
        }
    }
}
