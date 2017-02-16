using GrygierSite.Models;
using GrygierSite.ViewModels;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _context.Categories.Where(c => c.Id != 2).ToList(),
                Title = "Add new product",
                Action = "Create"
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.Where(c => c.Id != 2).ToList();
                return View("ProductForm", viewModel);
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
                ThumbnailPath = viewModel.GetThumbnailPath(),
                Price = viewModel.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Single(p => p.Id == id);

            var viewModel = new DetailsViewModel(product)
            {
                AuthenticatedUser = User.Identity.IsAuthenticated
            };

            product.Id = id;

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Single(p => p.Id == id);

            var viewModel = new ProductFormViewModel(product)
            {
                Categories = _context.Categories.Where(c => c.Id != 2).ToList(),
                Title = "Update product",
                Action = "Edit"
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.Where(c => c.Id != 2).ToList();
                return View("ProductForm", viewModel);
            }

            var productFromDb = _context.Products.Single(p => p.Id == viewModel.Id);

            productFromDb.Name = viewModel.Name;
            productFromDb.Description = viewModel.Description;
            productFromDb.CategoryId = viewModel.Category;
            productFromDb.Price = viewModel.Price;
            productFromDb.MarketUrl = viewModel.MarketUrl;
            productFromDb.LastUpdate = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}