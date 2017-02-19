using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;

namespace GrygierSite.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public Product GetProductWithCategory(int productId)
        {
            return _context.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == productId);
        }

        public Product GetProduct(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(p => p.Category);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}