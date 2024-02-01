using Master_in_Web_APPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Master_in_Web_APPI.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
        new Shirt{ShirtId=1, Brand="Vanhusen",Color="Green",Price=12.2,Gender="M",Size=23},
        new Shirt{ShirtId=2,Brand="V Dot",Color="Pale green", Price=13.2,Gender="M",Size=23},
        new Shirt{ShirtId=3,Brand="Helicat",Color="Yellow",Price=12.0,Gender ="M",Size=23}
        };
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }
        public static Shirt? ShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
        public static List<Shirt> GetAllShirts()
        {
            return shirts;
        }
        public static void AddShirt(Shirt shirt)
        {
            int nxtShirtId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = nxtShirtId + 1;
            shirts.Add(shirt);
        }
        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
        }

        public static void DeleteShirt(int shirtId)
        {
            var shirt = ShirtById(shirtId);
            if (shirt != null)
                shirts.Remove(shirt);
        }
    }
}
