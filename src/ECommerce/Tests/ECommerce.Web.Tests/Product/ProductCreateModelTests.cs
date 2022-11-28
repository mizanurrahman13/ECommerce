using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using Moq;
using Shouldly;
using BO = ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Web.Models;
using Org.BouncyCastle.Security;

namespace ECommerce.Web.Tests.Product
{
    public class ProductCreateModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductCreateModel _productCreateModel;
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
            _productCreateModel = _autoMock.Create<ProductCreateModel>();
            _baseModel = _autoMock.Mock<BaseModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _productServiceMock?.Reset();
            _mapperMock?.Reset();
            _baseModel?.Reset();
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateProductAsync_ProductImageIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // arrange
            var product = new BO.Product
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139000,
            };

            product.ProductImages = null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            var categoryIdOne = Guid.NewGuid();
            var cetegoryIdTwo = Guid.NewGuid();
            string[] categoriesId = new string[2] { categoryIdOne.ToString(), cetegoryIdTwo.ToString() };

            _productServiceMock.Setup(p => p.CreateProduct(product))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.Product>(_productCreateModel))
                .Returns(product).Verifiable();

            //Act & Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Should.ThrowAsync<InvalidParameterException>(async
                () => await _productCreateModel.CreateProduct(imageUrls, categoriesId)
            );
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateProductAsync_ProductCategoryIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // arrange
            var product = new BO.Product
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139000,
            };

            product.ProductCategories = null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            var categoryIdOne = Guid.NewGuid();
            var cetegoryIdTwo = Guid.NewGuid();
            string[] categoriesId = new string[2] { categoryIdOne.ToString(), cetegoryIdTwo.ToString() };

            _productServiceMock.Setup(p => p.CreateProduct(product))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.Product>(_productCreateModel))
                .Returns(product).Verifiable();

            //Act & Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Should.ThrowAsync<InvalidParameterException>(async
                () => await _productCreateModel.CreateProduct(imageUrls, categoriesId)
            );
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateProductAsync_ProductDiscountedPriceIsHigh_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // arrange
            var product = new BO.Product
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 141000,
            };

            product.ProductCategories = null!;
            product.ProductImages= null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            var categoryIdOne = Guid.NewGuid();
            var cetegoryIdTwo = Guid.NewGuid();
            string[] categoriesId = new string[2] { categoryIdOne.ToString(), cetegoryIdTwo.ToString() };

            _productServiceMock.Setup(p => p.CreateProduct(product))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.Product>(_productCreateModel))
                .Returns(product).Verifiable();

            //Act & Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Should.ThrowAsync<Exception>(async
                () => await _productCreateModel.CreateProduct(imageUrls, categoriesId)
            );
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        [Test, Category("Unit Test")]
        public async Task CreateProductAsync_ProvidedDataIsFine_CreateProductAsync()
        {
            // arrange
            var product = new BO.Product
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139000,
            };

            product.ProductImages = null!;
            product.ProductCategories = null!;

            var imageUrls = new List<string>();
            imageUrls.Add("Demo.png");
            imageUrls.Add("User.png");

            var categoryIdOne = Guid.NewGuid();
            var cetegoryIdTwo = Guid.NewGuid();
            string[] categoriesId = new string[2] { categoryIdOne.ToString(), cetegoryIdTwo.ToString() };

            _productServiceMock.Setup(p => p.CreateProduct(product))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.Product>(_productCreateModel))
                .Returns(product).Verifiable();

            //Act
            await _productCreateModel.CreateProduct(imageUrls, categoriesId);

            //Act & Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }
    }
}
