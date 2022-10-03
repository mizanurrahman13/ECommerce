using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : AdminBaseController<CategoryController>
    {
        public CategoryController(ILogger<CategoryController> logger, ILifetimeScope scope)
        : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            var model = _scope.Resolve<DashboardModel>();
            return View(model);
        }

        public async Task<JsonResult> GetCategories()
        {
            var model = _scope.Resolve<CategoryListModel>();
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var list = await model.GetCategoryAsync(dataTableModel);
            return Json(list);
        }
    }
}
