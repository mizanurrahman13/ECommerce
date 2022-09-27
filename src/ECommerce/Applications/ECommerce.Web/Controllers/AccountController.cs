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

        public async Task<IActionResult> Register(string returnUrl = null)
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
