using Master_in_Web_APPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Master_in_Web_APPI.Filters.ActionFilters
{
    public class ShirtValidate_ShirtIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext dbContext;

        public ShirtValidate_ShirtIdFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId != null)
            {
                if (shirtId <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "Invalid Shirt id");
                    var errorDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(errorDetails);
                }
                else
                {
                    var shirt = dbContext.Shirts.Find(shirtId.Value);
                    if (shirt == null)
                    {
                        context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist");
                        var errorDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(errorDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["shirt"] = shirt;
                    }
                }
            }
        }
    }
}
