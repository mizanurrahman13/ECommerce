using Autofac;
using AutoMapper;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class RegisterModel
    {
        private IUserManagerAdapter<ApplicationUser> _userManagerAdapter;
        private ISignInManagerAdapter<ApplicationUser> _signInManagerAdapter;
        private ILifetimeScope _lifetimeScope;
        private IMapper _mapper;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public RegisterModel()
        {

        }

        public RegisterModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
                                ISignInManagerAdapter<ApplicationUser> signInManagerAdapter,
                                IMailSenderService mailSenderService,
                                IMapper mapper)
        {
            _userManagerAdapter = userManagerAdapter;
            _signInManagerAdapter = signInManagerAdapter;
            _mapper = mapper;
        }

        internal void Resolve(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _userManagerAdapter = _lifetimeScope.Resolve<IUserManagerAdapter<ApplicationUser>>();
            _signInManagerAdapter = _lifetimeScope.Resolve<ISignInManagerAdapter<ApplicationUser>>();
            _mapper = _lifetimeScope.Resolve<IMapper>();
        }

        internal async Task<IdentityResult> CreateAsync()
        {
            var user = GetMember();
            return await _userManagerAdapter.CreateMemberAsync(user, Password);
        }

        internal async Task SignInAsync(string userName)
        {
            await _userManagerAdapter.SignInAsync(userName);
        }

        internal async Task GetExternalAuthenticationSchemesAsync()
        {
            ExternalLogins = (await _signInManagerAdapter.GetExternalSchemesAsync()).ToList();
        }

        internal async Task<IdentityResult> ConfirmEmailAsync(string userName, string code)
        {
            return await _userManagerAdapter.ConfirmEmailAsync(userName, code);
        }

        private ApplicationUser GetMember()
        {
            var user = new ApplicationUser
            {
                UserName = Email,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
            return user;
        }
    }
}
