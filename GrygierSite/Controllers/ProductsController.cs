﻿using GrygierSite.Core;
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
                TotalPages = (int)Math.Ceiling((double)(_unitOfWork.Products.Count() / 9)) + 1,
                Category = category,
                Action = "GetProducts"
            };

            if (category != Categories.All)
            {
                viewModel.Title = _unitOfWork.Categories.GetCategoryName((int)category);
                viewModel.TotalPages = (int)Math.Ceiling((double)(_unitOfWork.Products.Count((int)category) / 9)) + 1;
            }

            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //    return PartialView("ShowProducts", viewModel);

            if (Request.IsAjaxRequest())
                return PartialView("ShowProducts", viewModel);

            return View("ShowProducts", viewModel);
        }

        public ActionResult GetProductsByTag(string tagName, int page = 1)
        {
            Tag tag = _unitOfWork.Tags.GetTag(tagName);

            var products = _unitOfWork.Products.GetProductsWithTag(tagName);

            var viewModel = new ShowProductsViewModel
            {
                Products = products,
                Title = $"Tag - {tag.Name}",
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)(_unitOfWork.Products.Count(tagName) / 9)) + 1,
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
                Product = new Product(),
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

            var product = viewModel.Product;

            //TODO: Change viewmodel to use simple types instead of Product object
            //TODO: Add annotations to properties for validation
            //TODO: Map properties using automaper
            //product.Tags = new List<Tag>();
            //product.Tags.Add(_unitOfWork.Tags.GetTag(viewModel.Product.Tags.ToList()[0].Id));
            product.ThumbnailPath = viewModel.GetThumbnailPath();
            product.LastUpdate = product.DateOfIssue = DateTime.Now;

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetLastChildCategories();
                return View("ProductForm", viewModel);
            }

            var productFromDb = _unitOfWork.Products.GetProduct(viewModel.Product.Id);

            productFromDb.CategoryId = viewModel.Product.CategoryId;
            productFromDb.Description = viewModel.Product.Description;
            productFromDb.MarketUrl = viewModel.Product.MarketUrl;
            productFromDb.Name = viewModel.Product.Name;
            productFromDb.Price = viewModel.Product.Price;
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