using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : AdminBaseController<ProductController>
    {
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(ILogger<ProductController> logger, 
            ILifetimeScope scope,
            IWebHostEnvironment webHostEnvironment)
        : base(logger, scope)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var model = _lifetimeScope.Resolve<DashboardModel>();

            return View(model);
        }

        public JsonResult GetProducts()
        {
            var model = _lifetimeScope.Resolve<ProductListModel>();
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var list = model.GetProducts(dataTableModel);

            return Json(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = _lifetimeScope.Resolve<ProductCreateModel>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                model.Resolve(_lifetimeScope);
                try
                {
                    var imageUrls = model?.ImageUrlsParam?.Split(",");

                    var categoriesId = model?.CategoriesId?.Split(",");

                    List<string> validImages = new List<string>();

                    if (imageUrls == null)
                    {
                        validImages.Add("Files/NoImageFound.png");
                    }
                    else
                    {
                        foreach (var imageUrl in imageUrls)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl);
                            var validPath = imageUrl.Replace("\\", "/");
                            validImages.Add(validPath);
                        }
                    }
                    if (categoriesId == null)
                        await model?.CreateProduct(validImages, new string[] { "default" });
                    else
                        await model?.CreateProduct(validImages, categoriesId);

                    TempData["message"] = $"{model?.Name} is successfully added.";

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["message"] = ioe.Message;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData["message"] = "Product could not be added due to some error";
                }
            }

            return View(model);            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = _lifetimeScope.Resolve<ProductEditModel>();
            try
            {
                if (id == Guid.Empty)
                    throw new InvalidOperationException("Id must be provided to get product");

                await model.GetProduct(id);
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
        public async Task<IActionResult> Edit(ProductEditModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                model.Resolve(_lifetimeScope);

                try
                {
                    var imageUrls = model?.ImageUrlsParam?.Split(",");
                    List<string> validImages = new List<string>();
                    if (imageUrls == null)
                    {
                        validImages.Add("Files/NoImageFound.png");
                    }
                    else
                    {
                        foreach (var imageUrl in imageUrls)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                                               imageUrl);
                            var validPath = imageUrl.Replace("\\", "/");
                            if (validPath != "Files/NoImageFound.png")
                                validImages.Add(validPath);
                        }
                    }
                    await model?.UpdateProductAsync(validImages);
                    TempData["message"] = $"{model?.Name} is successfully updated ";

                    return RedirectToAction("Index");
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);

                    TempData["message"] = ioe.Message;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["message"] = "Product could not be updated due to some error";
                }
            }

            return View(model);
        }

        public JsonResult ImageByProductId(Guid productId)
        {
            var model = new ProductImageModel();
            model.Resolve(_lifetimeScope);

            var result = model.GetImagesByProductId(productId);

            return Json(result);
        }

        [HttpPost]
        public object ProductFeedVisibility(string id)
        {
            var model = _lifetimeScope.Resolve<ProductVisibilityChangeModel>();
            try
            {
                model.ChangeVisibility(new Guid(id));

                return new { Code = 200, Message = "Success" };
            }
            catch (Exception ioe)
            {
                _logger.LogError(ioe, ioe.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }

        [HttpPost]
        public object ProductFeatureAvailability(string id)
        {
            var model = _lifetimeScope.Resolve<ProductFeatureChangeModel>();
            try
            {
                model.ChangeFeatureProperty(new Guid(id));

                return new { Code = 200, Message = "Success" };
            }
            catch (Exception ioe)
            {
                _logger.LogError(ioe, ioe.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }

        [HttpPost]
        public object MakeTrash(string id)
        {
            var model = _lifetimeScope.Resolve<ProductRestoreModel>();
            try
            {
                model.MakeTrash(new Guid(id));

                return new { Code = 200, Message = "Success" };
            }
            catch (Exception ioe)
            {
                _logger.LogError(ioe, ioe.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }

        public IActionResult Trash()//for viewing deleted products
        {
            return View();
        }

        public JsonResult GetTrashedProducts()//sends all products to dataTable in View
        {
            var DataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _lifetimeScope.Resolve<TrashedProductListModel>();
            var obj = Json(model.GetAllTrashProducts(DataTableModel));

            return obj;
        }

        [HttpPost]
        public object RestoreProduct(string productId)
        {
            var model = _lifetimeScope.Resolve<ProductRestoreModel>();
            try
            {
                model.Restore(new Guid(productId));
                return new { Code = 200, Message = "Success" };
            }
            catch (Exception ioe)
            {
                _logger.LogError(ioe, ioe.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }

        [HttpPost]
        public object ForceDelete(string productId)
        {
            var model = _lifetimeScope.Resolve<ProductRestoreModel>();

            try
            {
                model.ForceDelete(Guid.Parse(productId));

                return new { Code = 200, Message = "Success" };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return new { Code = 400, Message = "Unsuccessful" };
        }
    }
}
