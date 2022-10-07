using AutoMapper;
using DevSkill.Http.Utilities;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryListModel : AdminLayoutModel
    {
        private readonly ICategoryService? _categoryService;

        public CategoryListModel()
        {

        }

        public CategoryListModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            ICategoryService categoryService, IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _categoryService = categoryService;
        }

        public async Task<object> GetCategoryAsync(DataTablesAjaxRequestModel model)
        {
            var data = await _categoryService!.GetCategoryAsync(model.PageIndex, model.PageSize,
                model.SearchText, model.GetSortText(new string[] { "ImageUrl", "Name", "Description" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.displayTotal,
                data = (from record in data.records
                        select new string[]
                        {
                                record.ImageUrl!,
                                record.Name!,
                                record.Description!,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _categoryService!.DeleteCategoryAsync(id);
        }
    }
}
