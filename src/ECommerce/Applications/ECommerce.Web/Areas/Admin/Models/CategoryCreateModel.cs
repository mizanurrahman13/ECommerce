using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryCreateModel : AdminLayoutModel
    {

        [StringLength(100, ErrorMessage = "Name should be less than 100 chars")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        private ICategoryService? _categoryService;

        public CategoryCreateModel()
        {

        }

        public CategoryCreateModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor, 
            ICategoryService categoryService,
            IMapper mapper)
           : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _categoryService = categoryService;
        }

        public override void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
            base.Resolve(scope);
        }

        public async Task CreateCategory()
        {
            await GetUserInfoAsync();
            var categoryBO = _mapper!.Map<Category>(this);
            await _categoryService!.CreateCategory(categoryBO);
        }
    }
}
