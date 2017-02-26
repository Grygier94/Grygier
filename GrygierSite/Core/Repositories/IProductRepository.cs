using GrygierSite.Core.Models;
using System.Collections.Generic;

namespace GrygierSite.Core.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        Product GetProduct(int id);
        Product GetProductWithCategory(int productId);
        IEnumerable<Product> GetProducts(int page = 1, int count = 9);
        IEnumerable<Product> GetProductsWithCategory(int page = 1, int count = 9);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsWithCategory();
        IEnumerable<Product> GetProductsFromCategory(int categoryId, int page, int count =);
    }
}