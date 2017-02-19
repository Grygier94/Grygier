using System.Collections.Generic;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void Add(Product product);
        Product GetProductWithCategory(int productId);
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsWithCategory();
        void Remove(Product product);
    }
}