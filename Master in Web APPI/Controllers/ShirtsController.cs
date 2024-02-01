using Master_in_Web_APPI.Data;
using Master_in_Web_APPI.Filters;
using Master_in_Web_APPI.Filters.ActionFilters;
using Master_in_Web_APPI.Filters.ExceptionFilters;
using Master_in_Web_APPI.Models;
using Master_in_Web_APPI.Repositories;
using Master_in_Web_APPI.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Master_in_Web_APPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ShirtsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllShirts()
        {
            return Ok(dbContext.Shirts.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(ShirtValidate_ShirtIdFilterAttribute))]
        public IActionResult GetShirtsById(int id)
        {
            return Ok(HttpContext.Items["shirt"]);
        }


        [HttpPost]
        [TypeFilter(typeof(ShirtValidate_CreateShirtFilterAttribute))]
        [Ensure_ShirtSizing]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            dbContext.Shirts.Add(shirt);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetShirtsById),
                new { id = shirt.ShirtId }, shirt);
        }


        [HttpDelete("{id}")]
        [TypeFilter(typeof(ShirtValidate_ShirtIdFilterAttribute))]
        public IActionResult DeleteShirtById(int id)
        {
            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;
            dbContext.Remove(shirtToDelete);
            dbContext.SaveChanges();
            return Ok(shirtToDelete);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ShirtValidate_ShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateShirtById(int id, Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Price = shirt.Price;
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
