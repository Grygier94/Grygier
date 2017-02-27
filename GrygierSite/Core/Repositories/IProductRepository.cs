using GrygierSite.Core.Models;
using System.Collections.Generic;

namespace GrygierSite.Core.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        int Count();
        int Count(int categoryId);
        Product GetProduct(int id);
        Product GetProductWithCategory(int productId);
        IEnumerable<Product> GetProducts(int page = 1, int pageSize = 9);
        IEnumerable<Product> GetProductsWithCategory(int page = 1, int pageSize = 9);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsWithCategory();
        IEnumerable<Product> GetProductsFromCategory(int categoryId, int page = 1, int pageSize = 9);
    }
}