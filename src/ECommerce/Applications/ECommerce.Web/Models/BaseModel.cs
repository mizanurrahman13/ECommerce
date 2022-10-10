using Autofac;
using AutoMapper;
using DevSkill.Http;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.DTOs;
using ECommerce.Membership.Services;
using ECommerce.Web.Enums;

namespace ECommerce.Web.Models
{
    public abstract class BaseModel
    {
        protected IUserManagerAdapter<ApplicationUser>? _userManagerAdapter;
        protected IHttpContextAccessor? _httpContextAccessor;        
        protected ILifetimeScope? _scope;
        protected IMapper? _mapper;
        protected ResponseModel _responseModel;
        public UserBasicInfoDto? UserInfo { get; private set; }

        public BaseModel()
        {
            _responseModel = new ResponseModel();
            _httpContextAccessor = new HttpContextAccessor();
        }

        public BaseModel(ILifetimeScope scope,
                            IUserManagerAdapter<ApplicationUser>? userManagerAdapter,
                            IHttpContextAccessor httpContextAccessor,
                            IMapper mapper)
        {
            _userManagerAdapter = userManagerAdapter;
            _scope = scope;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

        }

        public BaseModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter, 
            IHttpContextAccessor httpContextAccessor, 
            IMapper mapper)
        {
            _userManagerAdapter = userManagerAdapter;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public virtual void Resolve(ILifetimeScope lifetimeScope)
        {
            _scope = lifetimeScope;
            _userManagerAdapter = _scope.Resolve<IUserManagerAdapter<ApplicationUser>>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
            _mapper = _scope.Resolve<IMapper>();
        }
        public ResponseModel GetResponse()
        {
            if (_httpContextAccessor.HttpContext.Session.IsAvailable
                && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(_responseModel)))
            {
                var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(_responseModel));
                _httpContextAccessor.HttpContext.Session.Remove(nameof(_responseModel));
                return response;
            }
            else
            {
                return null;
            }
        }

        public void SetResponse(string message, ResponseTypes responseType, string area)
        {
            var response = new ResponseModel(message, responseType, area);
            _httpContextAccessor.HttpContext.Session.Set<ResponseModel>(nameof(_responseModel), response);
        }

        public void StatusMessage(string message, ResponseTypes response, string area)
        {
            if (response == ResponseTypes.Success)
                SetResponse(message, response, area);
            else if (response == ResponseTypes.Error)
                SetResponse(message, response, area);
        }

        private async Task GetMemberInfoAsync()
        {
            var userName = _httpContextAccessor!.HttpContext!.User.Identity!.Name;
            var userInfo = await _userManagerAdapter!.FindByEmailAsync(userName!);
            UserInfo = new UserBasicInfoDto();
            _mapper!.Map(userInfo, UserInfo);
        }

        public async Task GetUserInfoAsync()
        {
            if (!_httpContextAccessor!.HttpContext!.User!.Identity!.IsAuthenticated)
                throw new InvalidOperationException("Authenticated user required to access user information");

            if (!HasSessionKey("UserInfo"))
            {
                await GetMemberInfoAsync();
                SetSessionData<UserBasicInfoDto>("UserInfo", UserInfo!);
            }

            UserInfo = GetSessionData<UserBasicInfoDto>("UserInfo");
        }

        protected bool HasSessionKey(string key)
        {
            return _httpContextAccessor!.HttpContext!.Session.IsAvailable &&
                _httpContextAccessor.HttpContext.Session.Keys.Contains(key);
        }

        protected void SetSessionData<T>(string key, T data)
        {
            _httpContextAccessor!.HttpContext!.Session.Set(key, data);
        }

        protected T GetSessionData<T>(string key)
        {
            return _httpContextAccessor!.HttpContext!.Session.Get<T>(key);
        }
    }
}
