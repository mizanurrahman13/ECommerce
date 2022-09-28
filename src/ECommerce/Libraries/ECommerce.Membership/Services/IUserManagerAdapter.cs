using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Enums;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Membership.Services
{
    public interface IUserManagerAdapter<T> where T : class
    {
        Task<IdentityResult> CreateMemberAsync(T applicationUser, string password);
        Task CreateAccountAsync(T applicationUser, string password);
        bool ConfirmedAccount();
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<string> GetUserIdAsync(T applicationUser);
        Task<IdentityResult> ConfirmEmailAsync(string userName, string token);
        Task EmailConfirmationTokenAsync(T appUser);
        Task<IList<string>> GetUserRolesAsync(string userName);
        Task<bool> UpdateAccountAsync(ApplicationUser user);
        Task SignInAsync(Guid id);
        Task SignInAsync(string userName);
        string? GetUserId();
        Task<IdentityResult> ChangePassword(string userId,
                                            string newPassword,
                                            string confirmPassword);
        Task RolesAsync(string userid, RoleTypes[] types);
    }
}
