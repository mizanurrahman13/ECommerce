using AutoMapper;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Common;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductListModel : AdminLayoutModel
    {
        private readonly IProductService? _productService;
        private readonly ICategoryService? _categoryService;

        public ProductListModel()
        {

        }

        public ProductListModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<object> GetProductAsync(DataTablesAjaxRequestModel model)
        {
            var data = await _productService!.GetActiveProductsAsync(model.PageIndex, model.PageSize,
                model.SearchText, model.GetSortText(new string[] { "Name", "UnitPrice" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from productInfo in data.products
                        orderby productInfo.CreatedDate descending
                        select new string[]
                        {
                            (productInfo.ProductImages!=null)?
                                productInfo.ProductImages.Select(x => x.Url).FirstOrDefault().ToString():string.Empty,//->0
                            productInfo.Name,//->1
                            (productInfo.ProductCategories!=null)?
                            String.Join(",", productInfo.ProductCategories.Select(async x =>
                            {
                                var res = _categoryService.GetCategoryById(x.CategoryId);
                                return "[{"+res.Id+"}^{"+res.Name+"}]";
                            }
                            )):string.Empty,//->2
                            (productInfo.ProductInventory!=null)?
                            productInfo.ProductInventory.Quantity.ToString():string.Empty,//->3
                            productInfo.UnitPrice.ToString(),//->4
                            productInfo.DiscountedPrice.ToString(),//->5
                            Calculate.Discount((double)productInfo.UnitPrice,
                                (double)productInfo.DiscountedPrice),//->6
                            productInfo.ActiveStatus.ToString(),//->7
                            productInfo.Featured.ToString(),//->8
                            productInfo.Id.ToString()//->9
                        }).ToArray()
            };
        }

        public object GetProducts(DataTablesAjaxRequestModel model)
        {
            var data = _productService!.GetActiveProducts(model.PageIndex, model.PageSize,
                model.SearchText, model.GetSortText(new string[] { "Name", "UnitPrice" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from productInfo in data.products
                        orderby productInfo.CreatedDate descending
                        select new string[]
                        {
                            (productInfo.ProductImages!=null)?
                                productInfo.ProductImages.Select(x => x.Url).FirstOrDefault().ToString():string.Empty,//->0
                            productInfo.Name,//->1
                            (productInfo.ProductCategories!=null)?
                            String.Join(",", productInfo.ProductCategories.Select(x =>
                            {
                                var res = _categoryService.GetCategoryById(x.CategoryId);
                                return "[{"+res.Id+"}^{"+res.Name+"}]";
                            }
                            )):string.Empty,//->2
                            (productInfo.ProductInventory!=null)?
                            productInfo.ProductInventory.Quantity.ToString():string.Empty,//->3
                            productInfo.UnitPrice.ToString(),//->4
                            productInfo.DiscountedPrice.ToString(),//->5
                            Calculate.Discount((double)productInfo.UnitPrice,
                                (double)productInfo.DiscountedPrice),//->6
                            productInfo.ActiveStatus.ToString(),//->7
                            productInfo.Featured.ToString(),//->8
                            productInfo.Id.ToString()//->9
                        }).ToArray()
            };
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryService!.DeleteCategoryAsync(id);
        }

        public void Delete(Guid id)
        {
            _categoryService?.DeleteCategory(id);
        }
    }
}
