using Autofac.Extras.Moq;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text;
using ECommerce.Web.Enums;
using ECommerce.Membership.DTOs;
using ECommerce.Membership.Services;
using ECommerce.Membership.BusinessObjects;
using ApplicationUserEntity = ECommerce.Infrastructure.Entities.Membership.ApplicationUser;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Castle.Core.Internal;
using System.Security.Claims;
using Azure;

namespace ECommerce.Web.Tests
{
    [ExcludeFromCodeCoverage]
    public class BaseModelTests
    {
        private BaseModel _model;
        private AutoMock _autoMock;
        private Mock<ISession> _sessionMock;
        private Mock<ResponseModel> _responseModel;
        private Mock<HttpContext> _httpContextMock;
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private Mock<IUserManagerAdapter<ApplicationUser>> _userManagerAdaperMock;
        private Mock<IMapper> _mapperMock;
        private Mock<UserBasicInfoDto> _userBasicInfoDto;

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
            _sessionMock = _autoMock.Mock<ISession>();
            _responseModel = _autoMock.Mock<ResponseModel>();
            _httpContextMock = _autoMock.Mock<HttpContext>();
            _httpContextAccessorMock = _autoMock.Mock<IHttpContextAccessor>();
            _model = _autoMock.Create<BaseModel>();
            _userManagerAdaperMock = _autoMock.Mock<IUserManagerAdapter<ApplicationUser>>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _userBasicInfoDto = _autoMock.Mock<UserBasicInfoDto>();
        }

        [TearDown]
        public void TestCleanup()
        {
            _sessionMock?.Reset();
            _responseModel?.Reset();
            _httpContextMock?.Reset();
            _httpContextAccessorMock.Reset();
            _userManagerAdaperMock?.Reset();
            _mapperMock?.Reset();
            _userBasicInfoDto?.Reset();
        }

        [Test, Category("Unit Test")]
        public void SetResponse_ProvideProperties_SetSession()
        {
            //Arrange
            var message = "Testing";
            var responseType = ResponseTypes.Info;
            var area = "admin";
            var response = new ResponseModel(message, responseType, area);
            var jsonSerializerOptions = new JsonSerializerOptions();


            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(_httpContextMock.Object).Verifiable();
            _httpContextMock.Setup(x => x.Session).Returns(_sessionMock.Object).Verifiable();
            _sessionMock.Setup(x => x.Set(nameof(_responseModel), It.Is<byte[]>(y => Enumerable
            .SequenceEqual(y, Encoding.ASCII.GetBytes(JsonSerializer.Serialize(response, jsonSerializerOptions)))))).Verifiable();

            //Act
            _model.SetResponse(message, responseType, area);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _httpContextMock.VerifyAll(),
                () => _responseModel.VerifyAll(),
                () => _httpContextAccessorMock.VerifyAll(),
                () => _sessionMock.VerifyAll()
            );
        }

        //[Test]
        //public async Task GetUserInfoAsync_UserExists_GetUserInfoAsync()
        //{
        //    // Arrange
        //    var userInfo = new UserBasicInfoDto
        //    {
        //        FirstName = "Lamia",
        //        LastName = "Ahmed",
        //        Email = "lamia@gmail.com",
        //        UserName = "lamia@gmail.com"
        //    };

        //    var applicationUser = new ApplicationUser
        //    {
        //        FirstName = "Lamia",
        //        LastName = "Ahmed",
        //        Email = "lamia@gmail.com",
        //        UserName = "lamia@gmail.com"
        //    };

        //    var applicationUserEntity = new ApplicationUserEntity
        //    {
        //        FirstName = "Lamia",
        //        LastName = "Ahmed",
        //        Email = "lamia@gmail.com",
        //        UserName = "lamia@gmail.com"
        //    };

        //    const string userName = "lamia@gmail.com";
        //    var jsonSerializerOptions = new JsonSerializerOptions();

        //    //var context = new DefaultHttpContext();

        //    //var identity = new ClaimsIdentity("userName");
        //    //context.User = new ClaimsPrincipal(identity);

        //    //_httpContextAccessorMock.Setup(_ => _.HttpContext).Returns(context);
        //    //byte[] dummy = System.Text.Encoding.UTF8.GetBytes(userName);

        //    ////_httpContextAccessorMock.Setup(x => x.HttpContext).Returns(_httpContextMock.Object).Verifiable();
        //    ////_httpContextMock.Setup(x => x.Session).Returns(_sessionMock.Object).Verifiable();

        //    //_sessionMock.Setup(x => x.TryGetValue(It.IsAny<string>(), out dummy!)).Returns(true).Verifiable();

        //    _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(_httpContextMock.Object).Verifiable();
        //    _httpContextMock.Setup(x => x.Session).Returns(_sessionMock.Object).Verifiable();
        //    _sessionMock.Setup(x => x.Set(nameof(_userBasicInfoDto), It.Is<byte[]>(y => Enumerable
        //        .SequenceEqual(y, Encoding.ASCII.GetBytes(JsonSerializer.Serialize(userInfo, jsonSerializerOptions)))))).Verifiable();

        //    _userManagerAdaperMock.Setup(u => u.FindByUsernameAsync(userName))
        //        .ReturnsAsync(applicationUser).Verifiable();

        //    _mapperMock.Setup(x => x.Map<ApplicationUser>(applicationUserEntity))
        //        .Returns(applicationUser).Verifiable();

        //    // Act
        //    await _model.GetUserInfoAsync();

        //    // Assert
        //    this.ShouldSatisfyAllConditions(
        //        () => _userManagerAdaperMock.VerifyAll(),
        //        () => _mapperMock.VerifyAll()
        //    );
        //}
    }
}
