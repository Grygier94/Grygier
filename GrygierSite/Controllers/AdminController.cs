using GrygierSite.Models;
using GrygierSite.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Dashboard()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _context.Categories.Where(c => c.Id != 2).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.Where(c => c.Id != 2).ToList();
                return View("Create", viewModel);
            }

            viewModel.Thumbnail.SaveAs(Path.Combine(Server.MapPath("~/"), viewModel.GetThumbnailPath()));

            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                LastUpdate = DateTime.Now,
                DateOfIssue = DateTime.Now,
                CategoryId = viewModel.Category,
                MarketUrl = viewModel.MarketUrl,
                ThumbnailPath = viewModel.GetThumbnailPath()
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}