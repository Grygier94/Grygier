﻿using GrygierSite.Models;
using GrygierSite.ViewModels;
using System;
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
        public ActionResult Create(ProductFormViewModel viewModel)
        {

            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                LastUpdate = DateTime.Now,
                DateOfIssue = DateTime.Now,
                CategoryId = viewModel.Category,
                MarketUrl = viewModel.MarketUrl
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}