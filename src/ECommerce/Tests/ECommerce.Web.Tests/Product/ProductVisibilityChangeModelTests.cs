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
    public class ProductVisibilityChangeModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductVisibilityChangeModel? _productVisibilityChangeModel;
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
            _productVisibilityChangeModel = _autoMock.Create<ProductVisibilityChangeModel>();
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
        public void ChangeVisibility_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productVisibilityChangeModel!.ChangeVisibility(id));
        }

        [Test, Category("Unit Test")]
        public void ChangeVisibility_ProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productVisibilityChangeModel!.ChangeVisibility(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void ChangeVisibility_ProductExists_ChangeVisibility()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var product = new BO.Product()
            {
                Id = id,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            _productServiceMock.Setup(p => p.GetProductById(product.Id))
                .Returns(product).Verifiable();
            _productServiceMock.Setup(p => p.UpdateProduct(product))
                .Verifiable();
            _productServiceMock.Setup(e => e.ChangeVisibility(id))
                .Verifiable();

            // Act
            _productVisibilityChangeModel!.ChangeVisibility(id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll()
            );
        }
    }
}
