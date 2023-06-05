using SuperShop.Web.Data.Entities;
using SuperShop.Web.Models;
using System.IO;

namespace SuperShop.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Product ToProduct(ProductViewModel model, string path, bool isNew)
        {
            return new Product
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                ImageURL = path,
                IsAvailable = model.IsAvailable,
                LastPurchase = model.LastPurchase,
                LastSale = model.LastSale,
                Price = model.Price,
                Stock = model.Stock,
                User = model.User
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                IsAvailable = product.IsAvailable,
                LastPurchase = product.LastPurchase,
                LastSale = product.LastSale,
                Price = product.Price,
                Stock = product.Stock,
                User = product.User,
                ImageURL = product.ImageURL,
                Name = product.Name,
            };
        }
    }
}
