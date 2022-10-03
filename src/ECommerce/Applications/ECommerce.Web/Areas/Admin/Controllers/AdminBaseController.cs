using Autofac;
using ECommerce.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class AdminBaseController<T> : BaseController<T>
        where T : Controller
    {
        public AdminBaseController(ILogger<T> logger, ILifetimeScope scope)
            : base(logger, scope)
        {

        }
    }
}
