using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Exceptions;
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
            var model = _lifetimeScope.Resolve<DashboardModel>();

            return View(model);
        }

        public async Task<JsonResult> GetCategories()
        {
            var model = _lifetimeScope.Resolve<CategoryListModel>();
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var list = await model.GetCategoryAsync(dataTableModel);

            return Json(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = _lifetimeScope.Resolve<CategoryCreateModel>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            try
            {
                model.Resolve(_lifetimeScope);

                if (model.ImageUrl == null)
                {
                    model.ImageUrl += "Files/NoImageFound.png";
                }
                await model.CreateCategory();

                if (!ModelState.IsValid)
                    throw new InvalidOperationException("provide value for field.");

                //ViewResponse("Category has been created successfully.", ResponseTypes.Success);
                TempData["message"] = $"{model?.Name} is successfully added ";

                return RedirectToAction("Index");
            }
            catch (DuplicateException ex)
            {
                //ViewResponse(ex.Message, ResponseTypes.Error);
                TempData["message"] = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                //if (ex.Message == "Failed to create category")

                //    ViewResponse(ex.Message, ResponseTypes.Error);
                TempData["message"] = ex.Message;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = _lifetimeScope.Resolve<CategoryEditModel>();
            try
            {
                if (id == Guid.Empty)
                    throw new InvalidOperationException("Id must be provided to get category");

                await model.GetCategory(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditModel model)
        {
            model.Resolve(_lifetimeScope);
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException("failed to update category detail");

                await model.UpdateCategoryAsync();

                TempData["message"] = $"{model?.Name} is successfully updated";
                //ViewResponse("Category successfully updated.", ResponseTypes.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                TempData["message"] = ex.Message;
                //ViewResponse(ex.Message, ResponseTypes.Error);

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public object CategoryDelete(string id)
        {
            var model = _lifetimeScope.Resolve<CategoryListModel>();
            try
            {
                model.Delete(new Guid(id));

                return new { Code = 200, Message = "Success" };
            }
            catch (Exception ioe)
            {
                _logger.LogError(ioe, ioe.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }

        public JsonResult ImageByCategoryId(Guid categoryId)
        {
            var model = new CategoryImageModel();
            model.Resolve(_lifetimeScope);

            var result = model.GetImageByCategoryId(categoryId);

            return Json(result);
        }

        //public JsonResult GetAllCategories()
        //{
        //    var model = _lifetimeScope.Resolve<CategoryListModel>();

        //    return Json(model.GetAllAsync());
        //}

        public JsonResult GetAllCategories()
        {
            var model = _lifetimeScope.Resolve<CategoryListModel>();

            return Json(model.GetAll());
        }
    }
}
