using Autofac.Extras.Moq;
using ECommerce.Web.Enums;
using ECommerce.Web.Models;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.Web.Tests
{
    [ExcludeFromCodeCoverage]
    public class ResponseModelTests
    {
        private AutoMock _autoMock;
        private ResponseModel _model;

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
        public void TestSetup()
        {
            _model = _autoMock.Create<ResponseModel>();
        }

        [TearDown]
        public void TestCleanup()
        {
        }

        [Test, Category("Unit Test")]
        [TestCase(ResponseTypes.Info, "Info")]
        [TestCase(ResponseTypes.Warning, "Warning")]
        [TestCase(ResponseTypes.Success, "Success")]
        [TestCase(ResponseTypes.Error, "Error")]
        public void GetHeaderText_ProvideResponseType_SetHeader(ResponseTypes type, string expectedResult)
        {
            //Act
            var result = _model.GetHeaderText(type);

            //Assert
            result.ShouldBe(expectedResult);
        }
    }
}
