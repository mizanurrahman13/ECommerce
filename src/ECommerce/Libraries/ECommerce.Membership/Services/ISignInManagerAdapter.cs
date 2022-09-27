using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Membership.Services
{
    public interface ISignInManagerAdapter<T> where T : class
    {
        Task<IEnumerable<AuthenticationScheme>> GetExternalSchemesAsync();
        Task SignInAsync(string userName);
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(T user);
    }
}
