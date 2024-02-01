using Master_in_Web_APPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Master_in_Web_APPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "VN", Color = "Green", Gender = "M", Price = 12.2, Size = 10 },
                new Shirt { ShirtId = 2, Brand = "LP", Color = "Maroon", Gender = "M", Price = 13.2, Size = 13 },
                new Shirt { ShirtId = 3, Brand = "Coco", Color = "yellow", Gender = "F", Price = 13.90, Size = 18 }
                );
        }
        public DbSet<Shirt> Shirts { get; set; }
    }
}
