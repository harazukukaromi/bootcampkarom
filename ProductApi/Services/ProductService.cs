using ProductApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();

        public ProductService()
        {
            // Data awal
            _products.Add(new Product { Id = 1, Name = "Laptop", Price = 15000000 });
            _products.Add(new Product { Id = 2, Name = "Mouse", Price = 200000 });
        }

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(Product updated)
        {
            var existing = GetById(updated.Id);
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Price = updated.Price;
            }
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            if (p != null) _products.Remove(p);
        }
    }
}
