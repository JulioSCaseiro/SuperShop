using SuperShop.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SuperShop.Web.Data
{
    public class MockRepository : IRepository
    {
        public void AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Id = 1, Name = "um", Price = 10
            });
            products.Add(new Product
            {
                Id = 2, Name = "dois", Price = 10
            });
            products.Add(new Product
            {
                Id = 3, Name = "três", Price = 10
            });
            return products;
        }

        public bool ProductExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
