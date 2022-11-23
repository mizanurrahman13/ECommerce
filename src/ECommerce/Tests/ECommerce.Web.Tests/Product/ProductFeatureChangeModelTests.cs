using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Web.Models;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.Web.Tests.Product
{
    [ExcludeFromCodeCoverage]
    public class ProductFeatureChangeModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductFeatureChangeModel? _productFeatureChangeModel;
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
            _productFeatureChangeModel = _autoMock.Create<ProductFeatureChangeModel>();
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
        public void ChangeFeatureProperty_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productFeatureChangeModel!.ChangeFeatureProperty(id));
        }

        [Test, Category("Unit Test")]
        public void ChangeFeatureProperty_ProductExists_ChangeFeatureProperty()
        {
            //Arrange
            var id = Guid.NewGuid();

            _productServiceMock.Setup(e => e.ChangeFeatureProperty(id))
                .Verifiable();

            // Act
            _productFeatureChangeModel!.ChangeFeatureProperty(id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll()
            );
        }
    }
}
