using AutoMapper;
using GrygierSite.Dtos;
using GrygierSite.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GrygierSite.Controllers.Api
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetProducts(string query = null)
        {
            var products = _context.Products.Include(p => p.Category);

            if (!String.IsNullOrWhiteSpace(query))
                products = products.Where(c => c.Name.Contains(query));

            var productDtos = products
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == id);

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok("Resource deleted successfully!");
        }
    }
}
