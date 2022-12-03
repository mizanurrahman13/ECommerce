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
    public class ProductListModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<ICategoryService> _categoryServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductListModel? _productListModel;
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
            _categoryServiceMock = _autoMock.Mock<ICategoryService>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _productListModel = _autoMock.Create<ProductListModel>();
            _baseModel = _autoMock.Mock<BaseModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _productServiceMock?.Reset();
            _categoryServiceMock?.Reset();
            _mapperMock?.Reset();
            _baseModel?.Reset();
        }

        [Test]
        public void Delete_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productListModel.Delete(id));
        }

        [Test, Category("Unit Test")]
        public void DeleteProduct_ReturnedProductId_ProductDeleted()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var product = new BO.Product()
            {
                Id = id,
            };

            _productServiceMock.Setup(p => p.DeleteProduct(product.Id)).Verifiable();

            //Act
            _productListModel!.Delete(id);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll()
            );
        }
    }
}
