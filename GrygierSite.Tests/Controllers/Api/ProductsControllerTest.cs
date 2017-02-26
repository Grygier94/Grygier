using FluentAssertions;
using GrygierSite.Controllers.Api;
using GrygierSite.Core;
using GrygierSite.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GrygierSite.Tests.Controllers.Api
{
    [TestClass]
    public class ProductsControllerTest
    {
        private ProductsController _controller;
        private Mock<IProductRepository> _mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IProductRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Products).Returns(_mockRepository.Object);

            _controller = new ProductsController(mockUoW.Object);
        }

        [TestMethod]
        public void GetProduct_NoProductWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.GetProduct(2);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void DeleteProduct_NoProductWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.DeleteProduct(1);

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
