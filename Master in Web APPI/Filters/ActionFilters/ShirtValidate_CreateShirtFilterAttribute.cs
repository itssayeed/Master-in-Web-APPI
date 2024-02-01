using Master_in_Web_APPI.Data;
using Master_in_Web_APPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Master_in_Web_APPI.Filters.ActionFilters
{
    public class ShirtValidate_CreateShirtFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext dbContext;

        public ShirtValidate_CreateShirtFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object as null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingShirt = dbContext.Shirts.FirstOrDefault(x =>
               !string.IsNullOrWhiteSpace(shirt.Brand) &&
               !string.IsNullOrWhiteSpace(x.Brand) &&
               x.Brand.ToLower() == shirt.Brand.ToLower() &&
               !string.IsNullOrWhiteSpace(shirt.Gender) &&
               !string.IsNullOrWhiteSpace(x.Gender) &&
               x.Gender.ToLower() == shirt.Gender.ToLower() &&
               !string.IsNullOrWhiteSpace(shirt.Color) &&
               !string.IsNullOrWhiteSpace(x.Color) &&
               x.Color.ToLower() == shirt.Color.ToLower() &&
               shirt.Size.HasValue &&
               x.Size.HasValue &&
              shirt.Size.Value == x.Size.Value);

                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("Shirt", "Shirt already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
