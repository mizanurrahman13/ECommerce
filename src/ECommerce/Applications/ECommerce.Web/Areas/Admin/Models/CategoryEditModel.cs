using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using Org.BouncyCastle.Security;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryEditModel : AdminLayoutModel
    {
        public Guid Id { get; set; }
        [StringLength(100, ErrorMessage = "Name should be less than 100 chars")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        private ICategoryService? _categoryService;

        public CategoryEditModel()
        {

        }

        public CategoryEditModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor, ICategoryService categoryService,
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

        public async Task GetCategory(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidParameterException("Category id can not be empty.");

            var category = await _categoryService!.GetCategoryByIdAsync(id);

            if (category == null)
                throw new InvalidParameterException("Category cann't be null.");

            _mapper!.Map(category, this);
        }

        public async Task UpdateCategoryAsync()
        {
            var category = _mapper!.Map<Category>(this);

            if (category == null!)
                throw new InvalidParameterException("Category cann't be null.");

            await _categoryService!.UpdateCategoryAsync(category);
        }
    }
}
