using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCartWebApi.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ShoppingCartContext _context;

        public ProductRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        public Product Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }



        public void DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            _context.Remove(product);
            _context.SaveChanges();
        }



        public IEnumerable<Product> GetAll()
        {
            return _context.Product;
        }



        public Product GetProduct(int id)
        {
            return _context.Product.FirstOrDefault(u => u.ProductId == id);
        }



        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
