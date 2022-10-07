using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerce.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetUsername()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;

            var currentUsername = !string.IsNullOrEmpty(userName)
                ? userName

                : "Anonymous";

            return currentUsername;
        }
    }
}
