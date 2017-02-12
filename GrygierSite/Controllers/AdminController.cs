using GrygierSite.Models;
using GrygierSite.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _context.Categories.Where(c => c.Id != 2).ToList()
            };

            return View(viewModel);
        }
    }
}