using Autofac;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : AdminBaseController<DashboardController>
    {
        public DashboardController(ILogger<DashboardController> logger, ILifetimeScope scope)
        : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            var model = _lifetimeScope.Resolve<DashboardModel>();
            return View(model);
        }
    }
}
