using Autofac;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILifetimeScope _lifetimeScope;

        public AccountController(ILogger<AccountController> logger,
            ILifetimeScope lifetimeScope)
        {
            _logger = logger;
            _lifetimeScope = lifetimeScope;
        }

        public async Task<IActionResult> Register(string returnUrl = null!)
        {
            var model = _lifetimeScope.Resolve<RegisterModel>();
            model.ReturnUrl = returnUrl;
            await model.GetExternalAuthenticationSchemesAsync();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.Resolve(_lifetimeScope);
            model.ReturnUrl ??= Url.Content("~/");
            await model.GetExternalAuthenticationSchemesAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await model.CreateAsync();

                    if (result.Succeeded)
                    {
                        return View("~/Views/Shared/_EmailVerifyRequestPartial.cshtml");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userName, string code)
        {
            var model = _lifetimeScope.Resolve<ConfirmEmailModel>();
            var registerModel = _lifetimeScope.Resolve<RegisterModel>();

            if (userName == null || code == null)
            {
                model.StatusMessage = "User not found!";
                model.IsSuccess = false;

                return View(model);
            }

            try
            {
                var result = await registerModel.ConfirmEmailAsync(userName, code);
                model.StatusMessage = result.Succeeded ? "Your account has been verified successfully." : "Account verification failed. Please try again.";
                model.IsSuccess = result.Succeeded ? true : false;

                await registerModel.SignInAsync(userName);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View(model);
        }

        public async Task<IActionResult> Login(string returnUrl = null!)
        {
            var model = _lifetimeScope.Resolve<LoginModel>();
            var registerModel = _lifetimeScope.Resolve<RegisterModel>();

            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, model.ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await model.SignOutAsync();
            await registerModel.GetExternalAuthenticationSchemesAsync();
            model.ReturnUrl = returnUrl;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            model.Resolve(_lifetimeScope);
            var registerModel = _lifetimeScope.Resolve<RegisterModel>();
            model.ReturnUrl ??= Url.Content("~/");

            await registerModel.GetExternalAuthenticationSchemesAsync();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await model.PasswordSignInAsync();
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    await model.RedirectByUserRole();
                    return LocalRedirect(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null!)
        {
            var model = _lifetimeScope.Resolve<LoginModel>();
            await model.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
