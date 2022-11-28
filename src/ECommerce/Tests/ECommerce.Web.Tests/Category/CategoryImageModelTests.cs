using Autofac.Extras.Moq;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Web.Areas.Admin.Models;
using Moq;
using Org.BouncyCastle.Security;
using Shouldly;
using BO = ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Web.Tests.Category
{
    public class CategoryImageModelTests
    {
        private AutoMock _autoMock;
        private Mock<ICategoryService>? _categoryServiceMock;
        private Mock<IMapper>? _mapperMock;
        private CategoryImageModel? _categoryImageModel;

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
            _categoryImageModel = _autoMock.Create<CategoryImageModel>();
        }

        [TearDown]
        public void TestCleanUP()
        {
            _categoryServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test]
        public void GetImageByCategoryId_ProvidedIdIsEmpty_ThrowException()
        {
            var id = Guid.Empty;

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _categoryImageModel!.GetImageByCategoryId(id)
            );
        }

        [Test, Category("Unit Test")]
        public void GetImageByCategoryId_CategoryEntityIsNull_ThrowException()
        {
            //Arrange
            Guid categoryId = Guid.NewGuid();
            BO.Category category = null!;

            _categoryServiceMock!.Setup(c => c.GetCategoryImageById(categoryId))
                .Returns(category).Verifiable();

            //Act & Assert
            Should.Throw<InvalidParameterException>(
               () => _categoryImageModel!.GetImageByCategoryId(categoryId)
            );
        }

        [Test, Category("Unit Test")]
        public void GetImageByCategoryId_CategoryExists_GetImageByCategoryId()
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

            _categoryServiceMock!.Setup(c => c.GetCategoryImageById(categoryId))
                .Returns(category).Verifiable();

            // Act
            _categoryImageModel!.GetImageByCategoryId(categoryId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _categoryServiceMock.VerifyAll()
            );
        }
    }
}
