using Autofac;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class LoginModel : PublicLayoutModel
    {
        private ISignInManagerAdapter<ApplicationUser> _signInManagerAdapter;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private IUserManagerAdapter<ApplicationUser> _userManagerAdapter;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private ILifetimeScope _lifetimeScope;

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginModel(ISignInManagerAdapter<ApplicationUser> signInManagerAdapter,
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                            IUserManagerAdapter<ApplicationUser> userManagerAdapter)
        {
            _signInManagerAdapter = signInManagerAdapter;
            _userManagerAdapter = userManagerAdapter;
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        internal void Resolve(ILifetimeScope lifetimeScope)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            _lifetimeScope = lifetimeScope;
            _signInManagerAdapter = _lifetimeScope.Resolve<ISignInManagerAdapter<ApplicationUser>>();
            _userManagerAdapter = _lifetimeScope.Resolve<IUserManagerAdapter<ApplicationUser>>();
            base.Resolve(_lifetimeScope);
        }

        internal async Task SignOutAsync()
        {
            await _signInManagerAdapter.SignOutAsync();
        }

        internal async Task<SignInResult> PasswordSignInAsync()
        {
            var user = GetMember();
            return await _signInManagerAdapter.PasswordSignInAsync(user);
        }

        public async Task RedirectByUserRole()
        {
            var roles = await _userManagerAdapter!.GetUserRolesAsync(Email);
            if (roles.Contains("Admin"))
            {
                this.ReturnUrl = "~/admin/dashboard";
            }
            else
            {
                this.ReturnUrl = "~/customer/shop";
            }
        }

        private ApplicationUser GetMember()
        {
            var user = new ApplicationUser
            {
                UserName = Email,
                Email = Email,
                RememberMe = RememberMe,
                Password = Password
            };
            return user;
        }
    }
}
