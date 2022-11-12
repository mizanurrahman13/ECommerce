using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using Moq;
using Shouldly;
using EO = ECommerce.Infrastructure.Entities;
using BO = ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Web.Models;
using ECommerce.Membership.DTOs;

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
        public async Task CreateProductAsync_InvitationCodeNoteProvided_ThrowException()
        {
            // arrange
            var product = new BO.Product {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139000,
            };

            var productEntity = new EO.Product
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139000,
            };

            var userInfo = new UserBasicInfoDto
            {
                FirstName = "Lamia",
                LastName = "Ahmed",
                Email = "lamia@gmail.com",
                UserName = "lamia@gmail.com"
            };

            product.ProductImages = null!;
            product.ProductCategories = null!;

            var imageUrls = new List<string>();
            imageUrls = null!;
            string[] categoriesId = null!;

            //mockDb.Setup(d => d.SaveItem(It.IsAny<object>())).Verifiable();
            //_baseModelMock.Setup(u => u.GetUserInfoAsync()).Returns(Task.FromResult(0)).Verifiable();
            //var basemodel = new BaseModel();
            //_baseModel.Setup(_ => basemodel).Returns(_baseModel.Object).Verifiable();

            _baseModel.Setup(u => u.GetUserInfoAsync()).Returns(Task.CompletedTask).Verifiable();

            await _productCreateModel.CreateProduct(imageUrls, categoriesId);

            //Act & Assert
            this.ShouldSatisfyAllConditions(
                () => _baseModel.VerifyAll()
            );
            //await Should.ThrowAsync<InvalidParameterException>(async
            //    () => await _productCreateModel.CreateProduct(imageUrls, categoriesId)
            //);
        }
    }
}
