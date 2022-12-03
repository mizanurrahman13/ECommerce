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
    public class CategoryCreateModelTests
    {
        private AutoMock _autoMock;
        private Mock<ICategoryService>? _categoryServiceMock;
        private Mock<IMapper>? _mapperMock;
        private CategoryCreateModel? _categoryCreateModel;

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
            _categoryCreateModel = _autoMock.Create<CategoryCreateModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _categoryServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test, Category("Unit Test")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateCategoryAsync_CategoryEntityIsNull_ThrowException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // arrange
            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            category = null!;

            _categoryServiceMock!.Setup(c => c.CreateCategory(category))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(_categoryCreateModel))
                .Returns(category).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(async
               () => await _categoryCreateModel!.CreateCategory()
            );
        }

        [Test, Category("Unit Test")]
        public async Task CreateCategoryAsync_ProvidedDataIsFine_CreateCategoryAsync()
        {
            // arrange
            var category = new BO.Category
            {
                Id = Guid.Parse("7E19EA51-993E-4745-9E7D-FF8B5813AF4E"),
                Name = "Default",
                Description = "This is Blah blah blah",
                ImageUrl = "Demo.png"
            };

            _categoryServiceMock!.Setup(c => c.CreateCategory(category))
               .Returns(Task.CompletedTask).Verifiable();

            _mapperMock!.Setup(x => x.Map<BO.Category>(_categoryCreateModel))
                .Returns(category).Verifiable();

            // Act
            await _categoryCreateModel!.CreateCategory();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _categoryServiceMock.VerifyAll(),
                () => _mapperMock.VerifyAll()
            );
        }
    }
}
