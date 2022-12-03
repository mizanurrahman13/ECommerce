using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using BO = ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Web.Tests.Category
{
    [ExcludeFromCodeCoverage]
    public class CategoryEditModelTests
    {
        private AutoMock _autoMock;
        private Mock<ICategoryService>? _categoryServiceMock;
        private Mock<IMapper>? _mapperMock;
        private CategoryEditModel? _categoryEditModel;

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
            _categoryServiceMock = _autoMock.Mock<ICategoryService>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _categoryEditModel = _autoMock.Create<CategoryEditModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _categoryServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetCategory_ProvidedIdIsEmpty_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var id = Guid.Empty;

            //Act & Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Should.ThrowAsync<InvalidParameterException>(
               async () => await _categoryEditModel!.GetCategory(id)
            );
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetCategory_CategoryEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //Arrange
            Guid categoryId = Guid.NewGuid();
            BO.Category category = null!;

            _categoryServiceMock!.Setup(e => e.GetCategoryByIdAsync(categoryId))
                .ReturnsAsync(category).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               async () => await _categoryEditModel!.GetCategory(categoryId)
            );
        }

        [Test, Category("Unit Test")]
        public async Task GetCategory_CategoryExists_GetCategory()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();
            var category = new BO.Category()
            {
                Id = categoryId,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _categoryServiceMock!.Setup(p => p.GetCategoryByIdAsync(categoryId))
                .ReturnsAsync(category).Verifiable();
            _mapperMock!.Setup(x => x.Map(category, _categoryEditModel))
                .Verifiable();

            // Act
            await _categoryEditModel!.GetCategory(categoryId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _categoryServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateCategoryAsync_CategoryEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //Arrange
            Guid categoryId = Guid.NewGuid();
            BO.Category category = null!;

            _categoryServiceMock!.Setup(p => p.UpdateCategoryAsync(category))
                .Returns(Task.CompletedTask).Verifiable();
            _mapperMock!.Setup(x => x.Map<BO.Category>(_categoryEditModel))
                .Returns(category).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               async () => await _categoryEditModel!.UpdateCategoryAsync()
            );
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateCategoryAsync_CategoryExists_UpdateCategoryAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //Arrange
            Guid categoryId = Guid.NewGuid();
            var category = new BO.Category()
            {
                Id = categoryId,
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _categoryServiceMock!.Setup(p => p.UpdateCategoryAsync(category))
                .Returns(Task.CompletedTask).Verifiable();
            _mapperMock!.Setup(x => x.Map<BO.Category>(_categoryEditModel))
                .Returns(category).Verifiable();

            // Act
            await _categoryEditModel!.UpdateCategoryAsync();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _categoryServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }
    }
}
