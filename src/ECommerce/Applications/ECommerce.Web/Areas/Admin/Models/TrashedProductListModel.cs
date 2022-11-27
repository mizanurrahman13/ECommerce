using AutoMapper;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class TrashedProductListModel : AdminLayoutModel
    {
        private readonly IProductRestoreService _productRestoreService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public TrashedProductListModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IProductService productService,
            ICategoryService categoryService,
            IProductRestoreService productRestoreService,
            IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productRestoreService = productRestoreService;
        }

        public object? GetAllTrashProducts(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _productService.GetTrashedProducts(
                    dataTableModel.PageIndex,
                    dataTableModel.PageSize,
                    dataTableModel.SearchText,
                    dataTableModel.GetSortText(
                        new string[] {"Name",
                                      "UnitPrice"}));
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from productInfo in data.trashedProducts
                        select new string[]
                        {
                        (productInfo.ProductImages!=null)?
                            productInfo.ProductImages.Select(x => x.Url).FirstOrDefault().ToString():string.Empty,
                        productInfo.Name!,
                        (productInfo.ProductCategories!=null)?
                        String.Join(",", productInfo.ProductCategories.Select(x =>
                                        _categoryService.GetCategoryById(x.CategoryId).Name)):string.Empty,
                        (productInfo.ProductInventory!=null)?
                        productInfo.ProductInventory.Quantity.ToString():string.Empty,
                        productInfo.UnitPrice.ToString(),
                        (productInfo!=null)?
                        _productRestoreService.GetTrashByProductId(productInfo.Id).TriggeredOn.ToString("F"):string.Empty,
                        productInfo.Id.ToString()
                        }).ToArray()
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
