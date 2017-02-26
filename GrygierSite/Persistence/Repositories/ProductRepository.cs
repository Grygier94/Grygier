using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrygierSite.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product GetProduct(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public Product GetProductWithCategory(int productId)
        {
            return _context.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(int page = 1, int count = 9)
        {
            return _context
                .Products
                .OrderByDescending(p => p.DateOfIssue)
                .Skip((page - 1) * count)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Product> GetProductsWithCategory(int page = 1, int count = 9)
        {
            return _context
                .Products
                .OrderByDescending(p => p.DateOfIssue)
                .Skip((page - 1) * count)
                .Take(count)
                .Include(p => p.Category)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context
                .Products
                .ToList();
        }

        public IEnumerable<Product> GetAllProductsWithCategory()
        {
            return _context
                .Products
                .Include(p => p.Category)
                .ToList();
        }

        public IEnumerable<Product> GetProductsFromCategory(int categoryId)
        {
            return _context
                .Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }
    }
}