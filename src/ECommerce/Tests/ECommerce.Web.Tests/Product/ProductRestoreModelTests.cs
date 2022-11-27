using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Web.Models;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using EO = ECommerce.Infrastructure.Entities;
using BO = ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.UnitOfWorks;

namespace ECommerce.Web.Tests.Product
{
    [ExcludeFromCodeCoverage]
    public class ProductRestoreModelTests
    {
        private AutoMock _autoMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<IProductRestoreService> _productRestoreServiceMock;
        private Mock<IProductRestoreRepository> _productRestoreRepositoryMock;
        private Mock<IECommerceUnitOfWork> _eCommerceUnitOfWorkMock;
        private Mock<IMapper> _mapperMock;
        private ProductRestoreModel? _productRestoreModel;
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
            _productRestoreServiceMock = _autoMock.Mock<IProductRestoreService>();
            _productRestoreRepositoryMock = _autoMock.Mock<IProductRestoreRepository>();
            _eCommerceUnitOfWorkMock = _autoMock.Mock<IECommerceUnitOfWork>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _productRestoreModel = _autoMock.Create<ProductRestoreModel>();
            _baseModel = _autoMock.Mock<BaseModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _productServiceMock?.Reset();
            _productRestoreServiceMock?.Reset();
            _productRestoreRepositoryMock?.Reset();
            _eCommerceUnitOfWorkMock?.Reset();
            _mapperMock?.Reset();
            _baseModel?.Reset();
        }

        [Test]
        public void MakeTrash_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.MakeTrash(id));
        }

        [Test, Category("Unit Test")]
        public void MakeTrash_ProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.MakeTrash(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void MakeTrash_ProductExists_MakeTrash()
        {
            // Arrange
            Guid productId = Guid.NewGuid();
            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice= 139000,
                DeleteQueue= true
            };

            var productDelete = new BO.ProductDelete()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id               
            };

            var productDeleteEntity = new EO.ProductDelete()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id
            };

            _productServiceMock.Setup(p => p.GetProductById(productId))
                .Returns(product).Verifiable();
            _productServiceMock.Setup(p => p.UpdateProduct(product)).Verifiable();
            _productRestoreServiceMock.Setup(pd => pd.Add(productDelete)).Verifiable();

            //_mapperMock.Setup(x => x.Map<EO.ProductDelete>(product))
            //    .Returns(productDeleteEntity).Verifiable();

            // Act
            _productRestoreModel!.MakeTrash(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _productRestoreServiceMock.VerifyAll()
            );
        }

        [Test]
        public void Restore_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.Restore(id));
        }

        [Test, Category("Unit Test")]
        public void Restore_ProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.Restore(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void Restore_TrashedProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.ProductDelete productDelete = null!;

            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            _productRestoreServiceMock.Setup(tp => tp.GetTrashByProductId(productId))
                .Returns(productDelete).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.Restore(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void Restore_ProductAndTrashedProductExists_RestoreProduct()
        {
            //Arrange
            Guid productId = Guid.NewGuid();

            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            var productDelete = new BO.ProductDelete()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id
            };            

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            _productRestoreServiceMock.Setup(tp => tp.GetTrashByProductId(productId))
                .Returns(productDelete).Verifiable();

            _productServiceMock.Setup(p => p.UpdateProduct(product)).Verifiable();

            _productRestoreServiceMock.Setup(pd => pd.Remove(productDelete.Id)).Verifiable();

            // Act
            _productRestoreModel!.Restore(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _productRestoreServiceMock.VerifyAll()
            );
        }

        [Test]
        public void ForceDelete_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.ForceDelete(id));
        }

        [Test, Category("Unit Test")]
        public void ForceDelete_ProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.Product product = null!;

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.ForceDelete(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void ForceDelete_TrashedProductEntityIsNull_ThrowException()
        {
            //Arrange
            Guid productId = Guid.NewGuid();
            BO.ProductDelete productDelete = null!;

            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            _productRestoreServiceMock.Setup(tp => tp.GetTrashByProductId(productId))
                .Returns(productDelete).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _productRestoreModel!.ForceDelete(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void ForceDelete_ProductAndTrashedProductExists_ForceDeleteProduct()
        {
            //Arrange
            Guid productId = Guid.NewGuid();

            var product = new BO.Product()
            {
                Id = productId,
                Name = "iPhone 14 Pro Max",
                UnitPrice = 140000,
                DiscountedPrice = 139000,
                DeleteQueue = true
            };

            var productDelete = new BO.ProductDelete()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id
            };

            _productServiceMock.Setup(e => e.GetProductById(productId))
                .Returns(product).Verifiable();

            _productRestoreServiceMock.Setup(tp => tp.GetTrashByProductId(productId))
                .Returns(productDelete).Verifiable();

            _productServiceMock.Setup(p => p.DeleteProduct(product.Id)).Verifiable();

            _productRestoreServiceMock.Setup(pd => pd.Remove(productDelete.Id)).Verifiable();

            // Act
            _productRestoreModel!.ForceDelete(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _productServiceMock.VerifyAll(),
                () => _productRestoreServiceMock.VerifyAll()
            );
        }
    }
}
