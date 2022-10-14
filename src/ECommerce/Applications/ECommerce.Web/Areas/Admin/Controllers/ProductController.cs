using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : AdminBaseController<ProductController>
    {
        public ProductController(ILogger<ProductController> logger, ILifetimeScope scope)
        : base(logger, scope)
        {
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<DashboardModel>();

            return View(model);
        }

        public async Task<JsonResult> GetProducts()
        {
            var model = _scope.Resolve<ProductListModel>();
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var list = await model.GetProductAsync(dataTableModel);

            return Json(list);
        }
    }
}
