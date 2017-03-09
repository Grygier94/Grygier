using AutoMapper;
using GrygierSite.Core;
using GrygierSite.Core.Models;
using GrygierSite.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //TODO: Add annotation if there is no products for given tag or category
        //TODO: Change look of hamburger icon and menu items in dropdown list
        public ActionResult GetProducts(Categories category = Categories.All, int page = 1)
        {
            var products = category == Categories.All
                ? _unitOfWork.Products.GetProducts(page).ToList()
                : _unitOfWork.Products.GetProductsFromCategory((int)category, page).ToList();

            var viewModel = new ShowProductsViewModel
            {
                Products = products,
                Title = "~ Grygier ~",
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(_unitOfWork.Products.Count() / 9m),
                Category = category,
                Action = "GetProducts"
            };

            if (category != Categories.All)
            {
                viewModel.Title = _unitOfWork.Categories.GetCategoryName((int)category);
                viewModel.TotalPages = (int)Math.Ceiling(_unitOfWork.Products.Count((int)category) / 9m);
            }

            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //    return PartialView("ShowProducts", viewModel);

            if (Request.IsAjaxRequest())
                return PartialView("ShowProducts", viewModel);

            return View("ShowProducts", viewModel);
        }

        public ActionResult GetProductsByTag(string tagName, int page = 1)
        {
            var tag = _unitOfWork.Tags.GetTag(tagName);

            var products = _unitOfWork.Products.GetProductsWithTag(tagName, page);

            var viewModel = new ShowProductsViewModel
            {
                Products = products,
                Title = $"Tag - {tag.Name}",
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(_unitOfWork.Products.Count(tagName) / 9m),
                TagName = tagName,
                Action = "GetProductsByTag"
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("ShowProducts", viewModel);

            return View("ShowProducts", viewModel);
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

            var product = Mapper.Map<ProductFormViewModel, Product>(viewModel);
            var tags = _unitOfWork.Tags.GetTags().Where(t => viewModel.TagIds.Contains(t.Id)).ToList();

            foreach (var tag in tags)
            {
                product.Tags.Add(tag);
            }

            product.ThumbnailPath = viewModel.GetThumbnailPath();
            product.LastUpdate = product.DateOfIssue = DateTime.Now;

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

            viewModel.Id = product.Id;
            viewModel.SaveThumbnailOnServer();
            product.ThumbnailPath = viewModel.GetThumbnailPath();
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

        //TODO: Implement active tags in Edit form
        [Authorize]
        public ActionResult Edit(int id)
        {
            var product = _unitOfWork.Products.GetProduct(id);

            var viewModel = Mapper.Map<Product, ProductFormViewModel>(product);
            viewModel.Categories = _unitOfWork.Categories.GetLastChildCategories();
            viewModel.Title = "Update product";
            viewModel.Action = "Edit";

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetLastChildCategories();
                return View("ProductForm", viewModel);
            }

            var productFromDb = _unitOfWork.Products.GetProduct(viewModel.Id);

            productFromDb.CategoryId = viewModel.CategoryId;
            productFromDb.Description = viewModel.Description;
            productFromDb.MarketUrl = viewModel.MarketUrl;
            productFromDb.Name = viewModel.Name;
            productFromDb.Price = viewModel.Price;
            productFromDb.LastUpdate = DateTime.Now;

            viewModel.SaveThumbnailOnServer();

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var categories = _unitOfWork.Categories.GetLastChildCategories();

            return PartialView("_CategoriesNav", categories);
        }

        [ChildActionOnly]
        public ActionResult GetRecentPosts()
        {
            List<Product> products = _unitOfWork
                                    .Products
                                    .GetAllProductsWithCategory()
                                    .OrderByDescending(p => p.DateOfIssue)
                                    .Take(5)
                                    .ToList();


            return PartialView("_RecentPosts", products);
        }

        [ChildActionOnly]
        public ActionResult GetTags()
        {
            var tags = _unitOfWork.Tags.GetTags(16);
            return PartialView("_Tags", tags);
        }
    }
}