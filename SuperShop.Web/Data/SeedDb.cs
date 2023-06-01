using Microsoft.AspNetCore.Identity;
using SuperShop.Web.Data.Entities;
using SuperShop.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _random = new Random();
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            var user = await _userHelper.GetUserByEmailAsync("caseironc@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Julio",
                    LastName = "Caseiro",
                    Email = "caseironc@gmail.com",
                    UserName = "caseironc@gmail.com",
                    PhoneNumber = "911789217"
                };
                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result!= IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error creating user in seeder");
                }

            }

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X", user);
                AddProduct("iPhone 11", user);
                AddProduct("iPhone 12", user);
                AddProduct("iPhone 13", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            }) ;
        }
    }
}
