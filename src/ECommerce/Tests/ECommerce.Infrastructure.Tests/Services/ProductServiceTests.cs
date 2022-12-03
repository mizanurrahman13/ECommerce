using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.UnitOfWorks;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Linq.Expressions;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;
using ProductImageEntity = ECommerce.Infrastructure.Entities.ProductImage;

namespace ECommerce.Infrastructure.Tests.Services
{
    public class ProductServiceTests
    {
        private AutoMock _autoMock;
        private Mock<IECommerceUnitOfWork> _eCommerceUnitOfWorkMock;
        private Mock<IProductRepository> _productRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private IProductService _productService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _autoMock = AutoMock.GetLoose();
        }

        [SetUp]
        public void Setup()
        {
            _eCommerceUnitOfWorkMock = _autoMock.Mock<IECommerceUnitOfWork>();
            _productRepositoryMock = _autoMock.Mock<IProductRepository>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _productService = _autoMock.Create<ProductService>();
        }

        [TearDown]
        public void TearDown()
        {
            _eCommerceUnitOfWorkMock.Reset();
            _productRepositoryMock.Reset();
            _mapperMock.Reset();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _autoMock.Dispose();
        }

        [Test]
        public async Task CreateProductAsync_ProductDoesNotExists_CreateProduct()
        {
            // Arrange
            var product = new Product
            {
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139500
            };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<ProductEntity, bool>>>())).Returns(Task.FromResult(0));

            _mapperMock.Setup(x => x.Map<ProductEntity>(product))
                .Returns(new ProductEntity() { Name = product.Name });

            _eCommerceUnitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.FromResult(true)).Verifiable();

            _productRepositoryMock.Setup(x => x.AddAsync(It.Is<ProductEntity>(n => n.Name == product.Name)))
                .Returns(Task.FromResult(true)).Verifiable();

            // Act
            await _productService.CreateProduct(product);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateProductAsync_ProductExists_ThrowDuplicateException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var product = new Product
            {
                Name = "iPhone 14 Pro Max",
                ActiveStatus = true,
                UnitPrice = 140000,
                DiscountedPrice = 139500
            };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(1);

            // Act
            Should.Throw<DuplicateException>(
                () => _productService.CreateProduct(product).GetAwaiter().GetResult()
            );
        }

        [Test]
        public void DeleteProduct_ProductDoesNotExists_ThrowError()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };

            ProductEntity productEntity = null!;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetByIdAsync(product.Id))
                .ReturnsAsync(productEntity);

            // Assert
            Should.Throw<InvalidOperationException>(
                () => _productService.DeleteProduct(product.Id)
            );
        }

        [Test]
        public async Task GetProductAsync_ProductExists_ReturnSize()
        {
            // Arrange
            var product = new ProductEntity
            {
                Id = Guid.Parse("17A7DFF9-34FD-44E6-98C2-AA9DD60392EF"),
                Name = "Mango",
                ActiveStatus = false,
                UnitPrice = 3000,
                DiscountedPrice = 2500
            };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetByIdAsync(product.Id))
                .ReturnsAsync(product);

            _mapperMock.Setup(x => x.Map<Product>(product))
                .Returns(new Product { Id = product.Id, Name = product.Name });

            // Act
            var result = await _productService.GetProductByIdAsync(product.Id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeSameAs(product)
            );
        }

        [Test]
        public void GetProductAsync_ProductDoesNotExists_ThrowException()
        {
            // Arrange
            var product = new ProductEntity
            {
                Id = Guid.Parse("9FF42BDB-C008-414B-B23B-850DB0A7C4D1"),
                Name = "WhiteMango",
                ActiveStatus = false,
                UnitPrice = 3000,
                DiscountedPrice = 2500
            };
            ProductEntity productEntity = null!;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetByIdAsync(product.Id))
                .ReturnsAsync(productEntity!);

            // Act

            // Assert
            Should.Throw<InvalidOperationException>(
                () => _productService.GetProductByIdAsync(product.Id).GetAwaiter().GetResult()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateProductAsync_SameNameExists_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(1);

            // Act

            // Assert
            Should.Throw<InvalidOperationException>(
                () => _productService.UpdateProductAsync(product).GetAwaiter().GetResult()
            );
        }

        [Test]
        public void UpdateProduct_ProductExists_ReturnProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };
            var productEntity = new ProductEntity
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };

            var listOfProduct = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(0).Verifiable();

            _productRepositoryMock.Setup(x => x.Get(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), "ProductImages")).Returns(listOfProduct).Verifiable();

            productEntity.ProductImages = null;

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            //Act
            _productService.UpdateProductAsync(product);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public async Task UpdateProductUnitPriceAsync_ProductExists_UpdateProductUnitPrice()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
            };
            var listOfProduct = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<ProductEntity, bool>>>())).ReturnsAsync(0);

            _productRepositoryMock.Setup(x => x.Get(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), "ProductImages")).Returns(listOfProduct);

            productEntity.ProductImages = null;

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            _eCommerceUnitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.FromResult(true)).Verifiable();

            // Act
            await _productService.UpdateProductAsync(product);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void GetActiveProducts_ProductExists_GetActiveProductList()
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = "iPhone";
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var listOfProduct = new List<Product>() { product };
            var listOfProductEntity = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(p => p.GetDynamic(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true))
                .Returns((listOfProductEntity, total, totalDisplay)).Verifiable();

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            //Act
            _productService.GetActiveProducts(pageIndex, pageSize, searchText, orderBy);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void GetActiveProducts_ProductSearchTextIsNull_ThrowArgumentNullException()
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = null!;
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var listOfProduct = new List<Product>() { product };
            var listOfProductEntity = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(p => p.GetDynamic(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true))
                .Returns((listOfProductEntity, total, totalDisplay)).Verifiable();

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            // Act and Assert 
            Should.Throw<ArgumentNullException>(
                () => _productService.GetActiveProducts(pageIndex, pageSize, searchText, orderBy)
            );
        }

        [Test]
        public async Task GetProductAsync_ProductExists_GetProductList()
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = "iPhone";
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var listOfProduct = new List<Product>() { product };
            var listOfProductEntity = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(p => p.GetDynamicAsync(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), orderBy, null, pageIndex, pageSize, true))
                .ReturnsAsync((listOfProductEntity, total, totalDisplay)).Verifiable();

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            //Act
            await _productService.GetProductAsync(pageIndex, pageSize, searchText, orderBy);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void ChangeProductVisibility_ProductIdIsEmpty_ThrowInvalidParameterException()
        {
            // Arrange
            var id = Guid.Empty;

            //Act & Assert 
            Should.Throw<InvalidParameterException>(
                () => _productService.ChangeVisibility(id)
            );
        }

        [Test]
        public void ChangeProductVisibility_ProductEntityIsNull_ThrowInvalidParameterException()
        {
            // Arrange
            var id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6");

            var productEntity = new ProductEntity();
            productEntity = null!;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetById(id))
                .Returns(productEntity);

            //Act & Assert 
            Should.Throw<InvalidParameterException>(
                () => _productService.ChangeVisibility(id)
            );
        }

        [Test]
        public void ChangeProductVisibility_ProductExists_ChangeProductVisibility()
        {
            // Arrange
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };

            var id = productEntity.Id;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetById(id))
                .Returns(productEntity);

            _eCommerceUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //Act
            _productService.ChangeVisibility(id);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll()
            );
        }

        [Test]
        public void ChangeProductFeatureProperty_ProductIdIsEmpty_ThrowInvalidParameterException()
        {
            // Arrange
            var id = Guid.Empty;

            //Act & Assert 
            Should.Throw<InvalidParameterException>(
                () => _productService.ChangeFeatureProperty(id)
            );
        }

        [Test]
        public void ChangeProductFeatureProperty_ProductEntityIsNull_ThrowInvalidParameterException()
        {
            // Arrange
            var id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6");

            var productEntity = new ProductEntity();
            productEntity = null!;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetById(id))
                .Returns(productEntity);

            //Act & Assert 
            Should.Throw<InvalidParameterException>(
                () => _productService.ChangeFeatureProperty(id)
            );
        }

        [Test]
        public void ChangeProductFeatureProperty_ProductExists_ChangeProductFeatureProperty()
        {
            // Arrange
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };

            var id = productEntity.Id;

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.GetById(id))
                .Returns(productEntity);

            _eCommerceUnitOfWorkMock.Setup(x => x.Save()).Verifiable();

            //Act
            _productService.ChangeFeatureProperty(id);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll()
            );
        }

        [Test]
        public void GetTrashedProducts_ProductExists_GetTrashedProductList()
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = "iPhone";
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = true
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = true
            };
            var listOfProduct = new List<Product>() { product };
            var listOfProductEntity = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(p => p.GetDynamic(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true))
                .Returns((listOfProductEntity, total, totalDisplay)).Verifiable();

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            //Act
            _productService.GetTrashedProducts(pageIndex, pageSize, searchText, orderBy);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void GetTrashedProducts_ProductDeleteQueIsFalse_ThrowNullReferenceException()
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = "iPhone";
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var productEntity = new ProductEntity()
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000,
                DeleteQueue = false
            };
            var listOfProduct = new List<Product>() { product };
            var listOfProductEntity = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(p => p.GetDynamic(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true))
                .Returns((listOfProductEntity, total, totalDisplay)).Verifiable();

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            // Act and Assert 
            Should.Throw<NullReferenceException>(
                () => _productService.GetTrashedProducts(pageIndex, pageSize, searchText, orderBy)
            );
        }

        [Test]
        public void GetProductImageById_ProductIdIsEmpty_ThrowInvalidParameterException()
        {
            // Arrange
            var Id = Guid.Empty;

            //Act & Assert 
            Should.Throw<InvalidParameterException>(
                () => _productService.GetProductImageById(Id)
            );
        }

        [Test]
        public void GetProductImageById_ProductExists_GetProductImageById()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };
            var productEntity = new ProductEntity
            {
                Id = Guid.Parse("1F7D0046-288E-4887-A251-BA8937A6DCC6"),
                Name = "iPhone 12 Pro Max",
                ActiveStatus = false,
                UnitPrice = 120000,
                DiscountedPrice = 119000
            };

            var productImage = new ProductImage
            {
                Id = Guid.Parse("168528CC-7BA4-452D-B4BF-D8032B3C2EF7"),
                Url = "Files\\NoImageFound.png",
                ProductId = product.Id
            };

            var productImageEntity = new ProductImageEntity
            {
                Id = Guid.Parse("168528CC-7BA4-452D-B4BF-D8032B3C2EF7"),
                Url = "Files\\NoImageFound.png",
                ProductId = product.Id
            };

            var listOfProductImage = new List<ProductImageEntity> { productImageEntity };
            var listOfProduct = new List<ProductEntity>() { productEntity };

            _eCommerceUnitOfWorkMock.Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(x => x.Get(It.Is<Expression<Func<ProductEntity, bool>>>
                (i => i.Compile()(productEntity)), "ProductImages")).Returns(listOfProduct).Verifiable();

            productEntity.ProductImages = listOfProductImage;

            _mapperMock.Setup(x => x.Map<Product>(productEntity))
                .Returns(product).Verifiable();

            //Act 
            _productService.GetProductImageById(productEntity.Id);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _productRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }
    }
}
