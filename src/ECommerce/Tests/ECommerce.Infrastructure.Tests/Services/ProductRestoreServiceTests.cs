using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.UnitOfWorks;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Linq.Expressions;
using BO = ECommerce.Infrastructure.BusinessObjects;
using EO = ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Tests.Services
{
    public class ProductRestoreServiceTests
    {
        private AutoMock _autoMock;
        private Mock<IECommerceUnitOfWork> _eCommerceUnitOfWorkMock;
        private Mock<IProductRestoreRepository>? _productRestoreRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private IProductRestoreService? _productRestoreService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _autoMock = AutoMock.GetLoose();
        }

        [SetUp]
        public void Setup()
        {
            _eCommerceUnitOfWorkMock = _autoMock.Mock<IECommerceUnitOfWork>();
            _productRestoreRepositoryMock = _autoMock.Mock<IProductRestoreRepository>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _productRestoreService = _autoMock.Create<ProductRestoreService>();
        }

        [TearDown]
        public void TearDown()
        {
            _eCommerceUnitOfWorkMock.Reset();
            _productRestoreRepositoryMock.Reset();
            _mapperMock.Reset();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _autoMock.Dispose();
        }

        [Test]
        public void Add_ProductDeleteEntityIsNull_ThrowException()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productDelete = new BO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteEntity = new EO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            productDelete = null!;

            // Act and Assert
            Should.Throw<InvalidParameterException>(
                () => _productRestoreService!.Add(productDelete)
            );
        }

        [Test]
        public void Add_ProductDeleteExists_Add()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productDelete = new BO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteEntity = new EO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            _eCommerceUnitOfWorkMock.Setup(x => x.ProductRestores)
                .Returns(_productRestoreRepositoryMock!.Object);

            _mapperMock.Setup(x => x.Map<EO.ProductDelete>(productDelete))
                .Returns(productDeleteEntity).Verifiable();

            _productRestoreRepositoryMock.Setup(x => x.Add(productDeleteEntity))
                .Verifiable();

            _eCommerceUnitOfWorkMock.Setup(x => x.Save())
                .Verifiable();

            //Act
            _productRestoreService!.Add(productDelete);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRestoreRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void Remove_ProductDeleteIdIsEmpty_ThrowException()
        {
            // Arrange
            var id = Guid.Empty;

            // Act and Assert
            Should.Throw<InvalidParameterException>(
                () => _productRestoreService!.Remove(id)
            );
        }

        [Test]
        public void Remove_ProductDeleteExists_Remove()
        {
            // Arrange
            var id = Guid.NewGuid();

            _eCommerceUnitOfWorkMock.Setup(x => x.ProductRestores)
                .Returns(_productRestoreRepositoryMock!.Object);

            _productRestoreRepositoryMock.Setup(x => x.Remove(id))
                .Verifiable();

            _eCommerceUnitOfWorkMock.Setup(x => x.Save())
                .Verifiable();

            //Act
            _productRestoreService!.Remove(id);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRestoreRepositoryMock.VerifyAll()
            );
        }

        [Test]
        public void GetTrashByProductId_ProductDeleteIdIsEmpty_ThrowException()
        {
            // Arrange
            var productId = Guid.Empty;

            // Act and Assert
            Should.Throw<InvalidParameterException>(
                () => _productRestoreService!.GetTrashByProductId(productId)
            );
        }

        [Test, Category("Unit Test")]
        public void GetTrashByProductId_ProductDeleteExists_GetTrashByProductId()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var productDelete = new BO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteEntity = new EO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteList = new List<EO.ProductDelete>() { productDeleteEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.ProductRestores)
                .Returns(_productRestoreRepositoryMock!.Object);

            _productRestoreRepositoryMock.Setup(x => x.Get(It.Is<Expression<Func<EO.ProductDelete, bool>>>
                (i => i.Compile()(productDeleteEntity)), string.Empty))
                .Returns(productDeleteList).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.ProductDelete>(productDeleteEntity))
                .Returns(productDelete).Verifiable();

            //Act
            _productRestoreService!.GetTrashByProductId(productId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _productRestoreRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
        public void GetTrashedProducts_ProductDeleteExists_GetTrashedProducts()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var productDelete = new BO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteEntity = new EO.ProductDelete
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                ProductId = productId,
                TriggeredOn = DateTime.UtcNow,
            };

            var productDeleteList = new List<EO.ProductDelete>() { productDeleteEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.ProductRestores)
                .Returns(_productRestoreRepositoryMock!.Object);

            _productRestoreRepositoryMock.Setup(x => x.GetAll())
                .Returns(productDeleteList).Verifiable();

            _mapperMock.Setup(x => x.Map<BO.ProductDelete>(productDeleteEntity))
                .Returns(productDelete).Verifiable();

            //Act
            _productRestoreService!.GetTrashedProducts();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _productRestoreRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }
    }
}
