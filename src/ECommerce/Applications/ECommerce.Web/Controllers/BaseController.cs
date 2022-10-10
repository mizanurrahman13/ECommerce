using Autofac;
using DevSkill.Http;
using ECommerce.Web.Enums;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class BaseController<T> : Controller where T : Controller
    {
        protected readonly ILogger<T> _logger;
        protected readonly ILifetimeScope _scope;

        public BaseController(ILogger<T> logger,
            ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        protected virtual void ViewResponse(string message, ResponseTypes type)
        {
            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = message,
                Type = type
            });
        }
    }
}
