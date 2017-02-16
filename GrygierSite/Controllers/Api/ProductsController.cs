using GrygierSite.Models;
using System.Linq;
using System.Web.Http;

namespace GrygierSite.Controllers.Api
{
    [System.Web.Http.Authorize]
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpDelete]
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
