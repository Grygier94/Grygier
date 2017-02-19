using GrygierSite.Core;
using GrygierSite.Core.ViewModels;
using System;
using System.IO;
using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _unitOfWork.Categories.GetLastChildCategories(),
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
                viewModel.Categories = _unitOfWork.Categories.GetLastChildCategories();
                return View("ProductForm", viewModel);
            }

            viewModel.Thumbnail.SaveAs(Path.Combine(Server.MapPath("~/"), viewModel.GetThumbnailPath()));

            var product = viewModel.Product;
            product.ThumbnailPath = viewModel.GetThumbnailPath();
            product.LastUpdate = product.DateOfIssue = DateTime.Now;

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult Details(int id)
        {
            var product = _unitOfWork.Products.GetProductWithCategory(id);

            var viewModel = new DetailsViewModel
            {
                Product = product,
                AuthenticatedUser = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var product = _unitOfWork.Products.GetProduct(id);

            var viewModel = new ProductFormViewModel()
            {
                Product = product,
                Categories = _unitOfWork.Categories.GetLastChildCategories(),
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
                viewModel.Categories = _unitOfWork.Categories.GetLastChildCategories();
                return View("ProductForm", viewModel);
            }

            var productFromDb = _unitOfWork.Products.GetProduct(viewModel.Product.Id);
            productFromDb = viewModel.Product;
            productFromDb.LastUpdate = DateTime.Now;

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }
    }
}