using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Exceptions;
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
    public class CategoryServiceTests
    {
        private AutoMock? _autoMock;
        private Mock<IECommerceUnitOfWork>? _eCommerceUnitOfWorkMock;
        private Mock<ICategoryRepository>? _categoryRepositoryMock;
        private Mock<IMapper>? _mapperMock;
        private CategoryService? _categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _autoMock = AutoMock.GetLoose();
        }

        [SetUp]
        public void Setup()
        {
            _eCommerceUnitOfWorkMock = _autoMock!.Mock<IECommerceUnitOfWork>();
            _categoryRepositoryMock = _autoMock!.Mock<ICategoryRepository>();
            _mapperMock = _autoMock!.Mock<IMapper>();
            _categoryService = _autoMock!.Create<CategoryService>();
        }

        [TearDown]
        public void TearDown()
        {
            _eCommerceUnitOfWorkMock.Reset();
            _categoryRepositoryMock.Reset();
            _mapperMock.Reset();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _autoMock!.Dispose();
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateCategory_CategoryExists_ThrowDuplicateException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<EO.Category, bool>>>())).ReturnsAsync(1);

            // Act
            Should.Throw<DuplicateException>(
                () => _categoryService!.CreateCategory(category).GetAwaiter().GetResult()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateCategory_CategoryDoesNotExists_CreateCategory()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<EO.Category, bool>>>())).ReturnsAsync(0);

            _mapperMock!.Setup(x => x.Map<EO.Category>(category))
                .Returns(new EO.Category() { Name = category.Name });

            _categoryRepositoryMock!.Setup(x => x.AddAsync(It.Is<EO.Category>(n => n.Name == category.Name)))
                .Returns(Task.FromResult(true)).Verifiable();

            _eCommerceUnitOfWorkMock!.Setup(x => x.SaveAsync())
                .Returns(Task.FromResult(true)).Verifiable();

            // Act
            await _categoryService!.CreateCategory(category);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetCategoryAsync_CategorySearchTextIsNull_ThrowArgumentNullException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = null!;
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var listOfCategory = new List<BO.Category>() { category };
            var listOfCategoryEntity = new List<EO.Category>() { categoryEntity };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(c => c.GetDynamicAsync(It.Is<Expression<Func<EO.Category, bool>>>
                (i => i.Compile()(categoryEntity)), orderBy, null, pageIndex, pageSize, true))
                .ReturnsAsync((listOfCategoryEntity, total, totalDisplay)).Verifiable();
            
            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
                .Returns(category).Verifiable();

            // Act and Assert 
            Should.Throw<ArgumentNullException>(
                () => _categoryService!.GetCategoryAsync(pageIndex, pageSize, searchText, orderBy)
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetCategoryAsync_CategoryExists_GetCategoryAsyncList()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            const int pageIndex = 1;
            const int pageSize = 10;
            const string searchText = "Default";
            const string orderBy = "Name";
            const int total = 10;
            const int totalDisplay = 10;

            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var listOfCategory = new List<BO.Category>() { category };
            var listOfCategoryEntity = new List<EO.Category>() { categoryEntity };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(c => c.GetDynamicAsync(It.Is<Expression<Func<EO.Category, bool>>>
                (i => i.Compile()(categoryEntity)), orderBy, null, pageIndex, pageSize, true))
                .ReturnsAsync((listOfCategoryEntity, total, totalDisplay)).Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
                .Returns(category).Verifiable();

            // Act
            await _categoryService!.GetCategoryAsync(pageIndex, pageSize, searchText, orderBy);

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _categoryRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void GetCategoryByIdAsync_CategoryIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
                () => _categoryService!.GetCategoryByIdAsync(id).GetAwaiter().GetResult()
            );
        }

        [Test]
        public void GetCategoryByIdAsync_CategoryEntityIsNull_ThrowException()
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };
            EO.Category categoryEntity = null!;

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetByIdAsync(category.Id))
                .ReturnsAsync(categoryEntity!);

            //Act & Assert
            Should.Throw<InvalidOperationException>(
                () => _categoryService!.GetCategoryByIdAsync(id).GetAwaiter().GetResult()
            );
        }

        [Test]
        public void GetCategoryByIdAsync_CategoryExists_ReturnCategory()
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };
            var categoryEntity = new EO.Category();

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetByIdAsync(category.Id))
                .ReturnsAsync(categoryEntity!);

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
                .Returns(category).Verifiable();

            //Act
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _categoryService!.GetCategoryByIdAsync(id);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _categoryRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
        public void GetCategoryById_CategoryIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
                () => _categoryService!.GetCategoryById(id)
            );
        }

        [Test]
        public void GetCategoryById_CategoryEntityIsNull_ThrowException()
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };
            EO.Category categoryEntity = null!;

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetById(id))
                .Returns(categoryEntity!);

            //Act & Assert
            Should.Throw<InvalidOperationException>(
                () => _categoryService!.GetCategoryById(id)
            );
        }

        [Test]
        public void GetCategoryById_CategoryExists_ReturnCategory()
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };
            var categoryEntity = new EO.Category();

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetById(id))
                .Returns(categoryEntity!);

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
                .Returns(category).Verifiable();

            //Act
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _categoryService!.GetCategoryById(id);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            //Assert 
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock.VerifyAll(),
                () => _categoryRepositoryMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateCategoryAsync_SameNameExists_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<EO.Category, bool>>>())).ReturnsAsync(1);

            // Act

            // Assert
            Should.Throw<InvalidOperationException>(
                () => _categoryService!.UpdateCategoryAsync(category).GetAwaiter().GetResult()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateCategoryAsync_CategoryEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            EO.Category categoryEntity = null!;

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<EO.Category, bool>>>())).ReturnsAsync(0);

            _categoryRepositoryMock.Setup(x => x.GetByIdAsync(category.Id))
                .ReturnsAsync(categoryEntity!).Verifiable();

            // Act

            // Assert
            Should.Throw<InvalidOperationException>(
                () => _categoryService!.UpdateCategoryAsync(category).GetAwaiter().GetResult()
            );
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateCategoryAsync_CategoryExists_UpdateCategoryAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(x => x.GetCountAsync(It
                .IsAny<Expression<Func<EO.Category, bool>>>())).ReturnsAsync(0);

            _mapperMock!.Setup(x => x.Map(category, categoryEntity))
                .Returns(categoryEntity);

            _categoryRepositoryMock.Setup(x => x.GetByIdAsync(category.Id))
                .ReturnsAsync(categoryEntity!).Verifiable();

            _eCommerceUnitOfWorkMock!.Setup(x => x.SaveAsync())
                .Returns(Task.FromResult(true)).Verifiable();

            // Act
            await _categoryService!.UpdateCategoryAsync(category);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test]
        public void DeleteCategoryAsync_CategoryIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
                () => _categoryService!.DeleteCategoryAsync(id)
            );
        }

        [Test]
        public void DeleteCategoryAsync_CategoryExists_DeleteCategoryAsync()
        {
            var id = Guid.NewGuid();

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(x => x.RemoveAsync(id))
                .Returns(Task.FromResult(true)).Verifiable();

            _eCommerceUnitOfWorkMock!.Setup(x => x.SaveAsync())
                .Returns(Task.FromResult(true)).Verifiable();

            // Act
            _categoryService!.DeleteCategoryAsync(id).GetAwaiter().GetResult();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll()
            );
        }

        [Test]
        public void GetImageByCategoryId_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _categoryService!.GetCategoryImageById(id)
            );
        }

        [Test, Category("Unit Test")]
        public void GetImageByCategoryId_CategoryExists_GetImageByCategoryId()
        {
            //Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryList = new List<EO.Category>() { categoryEntity };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(c => c.Get(It.Is<Expression<Func<EO.Category, bool>>>
                (i => i.Compile()(categoryEntity)), string.Empty))
                .Returns(categoryList).Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
               .Returns(category);

            //Act
            _categoryService!.GetCategoryImageById(id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
        public void GetAllAsync_CategoryExists_GetAllAsyncList()
        {
            //Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryList = new List<BO.Category>() { category };
            var categoryListEntity = new List<EO.Category>() { categoryEntity };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(c => c.GetAllAsync()).ReturnsAsync(categoryListEntity)
                .Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
               .Returns(category).Verifiable();

            //Act
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _categoryService!.GetAllAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
        public void GetAll_CategoryExists_GetAllList()
        {
            //Arrange
            var id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E");
            var category = new BO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryEntity = new EO.Category
            {
                Id = id,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            var categoryList = new List<BO.Category>() { category };
            var categoryListEntity = new List<EO.Category>() { categoryEntity };

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(c => c.GetAll()).Returns(categoryListEntity)
                .Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(categoryEntity))
               .Returns(category).Verifiable();

            //Act
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _categoryService!.GetAll();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll(),
                () => _mapperMock!.VerifyAll()
            );
        }

        [Test]
        public void DeleteCategory_CategoryIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
                () => _categoryService!.DeleteCategory(id)
            );
        }

        [Test]
        public void DeleteCategory_CategoryExists_DeleteCategory()
        {
            var id = Guid.NewGuid();

            _eCommerceUnitOfWorkMock!.Setup(x => x.Categories)
                .Returns(_categoryRepositoryMock!.Object);

            _categoryRepositoryMock!.Setup(x => x.Remove(id))
                .Verifiable();

            _eCommerceUnitOfWorkMock!.Setup(x => x.Save())
                .Verifiable();

            // Act
            _categoryService!.DeleteCategory(id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _eCommerceUnitOfWorkMock!.VerifyAll(),
                () => _categoryRepositoryMock!.VerifyAll()
            );
        }
    }
}
