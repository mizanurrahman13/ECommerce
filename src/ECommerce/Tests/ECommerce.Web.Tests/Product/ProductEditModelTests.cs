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

namespace ECommerce.Web.Tests.Product
{
    [ExcludeFromCodeCoverage]
    public class ProductEditModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductEditModel? _productEditModel;
        private Mock<BaseModel> _baseModel;

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
            _productEditModel = _autoMock.Create<ProductEditModel>();
            _baseModel = _autoMock.Mock<BaseModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _productServiceMock?.Reset();
            _mapperMock?.Reset();
            _baseModel?.Reset();
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetProduct_ProvidedIdIsEmpty_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               async () => await _productEditModel!.GetProduct(id)
            );
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetProduct_ProductEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductByIdAsync(productId))
                .ReturnsAsync(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               async () => await _productEditModel!.GetProduct(productId)
            );
        }

        [Test, Category("Unit Test")]
        public async Task GetProduct_ProductExists_GetProduct()
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

            _productServiceMock.Setup(p => p.GetProductByIdAsync(productId))
                .ReturnsAsync(product).Verifiable();
            _mapperMock.Setup(x => x.Map(product, _productEditModel))
                .Verifiable();

            // Act
            await _productEditModel!.GetProduct(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
        public async Task UpdateProductAsync_ProductExists_UpdateProductAsync()
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

            product.ProductImages = null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            _productServiceMock.Setup(p => p.UpdateProductAndImageAsync(product))
                .Returns(Task.CompletedTask).Verifiable();
            _mapperMock.Setup(x => x.Map<BO.Product>(_productEditModel))
                .Returns(product).Verifiable();

            // Act
            await _productEditModel!.UpdateProductAsync(imageUrls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateProductAsync_ProductEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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
            product = null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            _productServiceMock.Setup(p => p.UpdateProductAndImageAsync(product))
                .Returns(Task.CompletedTask).Verifiable();
            _mapperMock.Setup(x => x.Map<BO.Product>(_productEditModel))
                .Returns(product).Verifiable();

            // Act and Assert
            Should.Throw<InvalidParameterException>(
               async () => await _productEditModel!.UpdateProductAsync(imageUrls)
            );
        }
    }
}
