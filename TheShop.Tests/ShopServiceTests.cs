using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TheShop.Repository;
using TheShop.Repository.Interfaces;
using TheShop.Services;
using TheShop.Services.Interfaces;
using TheShop.Services.Suppliers;

namespace TheShop.Tests
{
    [TestClass]
    public class ShopServiceTests
    {
        private Mock<IArticleRepository> _articleRepositoryMock;
        private Mock<ILoggerService> _loggerServiceMock;
        private Mock<ISupplierManager> _supplierManagerMock;

        public ShopServiceTests()
        {
            _articleRepositoryMock = new Mock<IArticleRepository>();
            _loggerServiceMock = new Mock<ILoggerService>();
            _supplierManagerMock = new Mock<ISupplierManager>();
        }

        [TestMethod]
        public void TestOrderMethod()
        {
            // Arrange
            var articleId = 1;
            var supplierService1Mock = new Mock<SupplierService1>();

            supplierService1Mock
                .Setup(x => x.GetArticleById(articleId))
                .Returns(() => new Domain.Article()
                {
                    Id = articleId,
                    Price = 300
                });

            _supplierManagerMock.Setup(src => src.SupplierServices)
                .Returns(() => new List<ISupplierService>()
                {
                    supplierService1Mock.Object
                });

            var shopService = new ShopService(
                _articleRepositoryMock.Object,
                _loggerServiceMock.Object,
                _supplierManagerMock.Object
                );

            // Act
            var article1 = shopService.OrderArticle(1, 20);
            var article2 = shopService.OrderArticle(1, 500);

            // Assert
            Assert.IsNull(article1);
            Assert.IsNotNull(article2);
        }

        [TestMethod]
        public void TestSellMethod()
        {
            // Arrange
            var articleId = 1;
            var buyerId = 10;
            var supplierService1Mock = new Mock<SupplierService1>();

            supplierService1Mock
                .Setup(x => x.GetArticleById(articleId))
                .Returns(() => new Domain.Article()
                {
                    Id = articleId,
                    Price = 300,
                    BuyerId=10
                });

            _supplierManagerMock.Setup(src => src.SupplierServices)
                .Returns(() => new List<ISupplierService>()
                {
                    supplierService1Mock.Object
                });

            var shopService = new ShopService(
                _articleRepositoryMock.Object,
                _loggerServiceMock.Object,
                _supplierManagerMock.Object
                );

            // Act
            var article1 = shopService.OrderArticle(1, 20);
            var article2 = shopService.OrderArticle(1, 500);
            shopService.SellArticle(buyerId, article2);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => shopService.SellArticle(buyerId, article1));
            Assert.AreEqual(article2.BuyerId, buyerId);
        }
    }
}
