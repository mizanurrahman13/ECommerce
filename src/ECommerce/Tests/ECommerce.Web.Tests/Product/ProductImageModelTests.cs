using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Web.Models;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using BO = ECommerce.Infrastructure.BusinessObjects;
using EO = ECommerce.Infrastructure.Entities;

namespace ECommerce.Web.Tests.Product
{
    [ExcludeFromCodeCoverage]
    public class ProductImageModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductImageModel? _productImageModel;

        [OneTimeSetUp]
        public void ClassOneTimeSetUp()
        {
            _autoMock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassOneTimeTearDown()
        {
            _autoMock?.Dispose();
        }

        [SetUp]
        public void TestSetUp()
        {
            _productServiceMock = _autoMock.Mock<IProductService>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _productImageModel = _autoMock.Create<ProductImageModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _productServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test]
        public void GetImagesByProductId_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productImageModel!.GetImagesByProductId(id));
        }

        [Test, Category("Unit Test")]
        public void GetImagesByProductId_ProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductImageById(productId))
                .Returns(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productImageModel!.GetImagesByProductId(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void GetImagesByProductId_ProductExists_GetImagesByProductId()
        {
            // Arrange
            Guid productId = Guid.NewGuid();
            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            var productImage = new BO.ProductImage()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id
            };

            var productImageEntity = new EO.ProductImage()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id
            };

            product.ProductImages = new List<BO.ProductImage> { };

            _productServiceMock.Setup(p => p.GetProductImageById(productId))
                .Returns(product).Verifiable();

            // Act
            _productImageModel!.GetImagesByProductId(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll()
            );
        }
    }
}
