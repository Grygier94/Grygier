using AutoMapper;
using GrygierSite.Core;
using GrygierSite.Core.Dtos;
using GrygierSite.Core.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace GrygierSite.Controllers.Api
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetAllProducts(string query = null)
        {
            var products = _unitOfWork.Products.GetAllProductsWithCategory();

            if (!String.IsNullOrWhiteSpace(query))
                products = products.Where(c => c.Name.Contains(query));

            var productDtos = products
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _unitOfWork.Products.GetProductWithCategory(id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetProduct(id);

            if (product == null)
                return NotFound();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/") + product.ThumbnailPath;
            if (File.Exists(path))
                File.Delete(path);

            _unitOfWork.Products.Remove(product);
            _unitOfWork.Complete();

            return Ok("Resource deleted successfully!");
        }
    }
}
