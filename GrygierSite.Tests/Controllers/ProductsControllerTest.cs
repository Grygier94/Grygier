using GrygierSite.Controllers;
using GrygierSite.Core;
using GrygierSite.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace GrygierSite.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        private ProductsController _controller;
        private Mock<IProductRepository> _productRepository;
        private Mock<ICategoriesRepository> _categoryRepository;


        [TestInitialize]
        public void TestInitialize()
        {
            _productRepository = new Mock<IProductRepository>();
            _categoryRepository = new Mock<ICategoriesRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Products).Returns(_productRepository.Object);
            mockUoW.SetupGet(u => u.Categories).Returns(_categoryRepository.Object);

            _controller = new ProductsController(mockUoW.Object);
        }

        [TestMethod]
        public void Create_ValidRequest_ShouldReturnFormView()
        {
            var result = _controller.Create() as ViewResult;

            Assert.AreEqual("ProductForm", result.ViewName);
        }


    }
}
