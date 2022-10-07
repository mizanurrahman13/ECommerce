using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Web.Enums;
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

        [HttpGet]
        public IActionResult Create()
        {
            var model = _scope.Resolve<CategoryCreateModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            try
            {
                model.Resolve(_scope);

                if (model.ImageUrl == null)
                {
                    model.ImageUrl += "Files/NoImageFound.png";
                }
                await model.CreateCategory();

                if (!ModelState.IsValid)
                    throw new InvalidOperationException("provide value for field.");

                ViewResponse("Category has been created successfully.", ResponseTypes.Success);
                TempData["Msg"] = $"{model?.Name} is successfully added ";

                return RedirectToAction("Index");
            }
            catch (DuplicateException ex)
            {
                ViewResponse(ex.Message, ResponseTypes.Error);
                TempData["Msg"] = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                if (ex.Message == "Failed to create category")

                    ViewResponse(ex.Message, ResponseTypes.Error);
                TempData["Msg"] = ex.Message;
            }
            return View(model);
        }
    }
}
