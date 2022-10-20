using Autofac;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

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

                    TempData["message"] = $"{model?.Name} is successfully added ";

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
    }
}
