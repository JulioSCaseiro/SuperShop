using SuperShop.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X");
                AddProduct("iPhone 11");
                AddProduct("iPhone 12");
                AddProduct("iPhone 13");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
            });
        }
    }
}
