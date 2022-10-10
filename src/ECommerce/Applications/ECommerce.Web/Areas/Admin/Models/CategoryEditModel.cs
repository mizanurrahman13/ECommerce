using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.Services;
using System.ComponentModel.DataAnnotations;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Infrastructure.BusinessObjects;
using System.ComponentModel.Design;

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
            var category = await _categoryService!.GetCategoryByIdAsync(id);
            MapCategory(category);
        }

        public async Task UpdateCategoryAsync()
        {
            var category = MapCategory();
            await _categoryService!.UpdateCategoryAsync(category);
        }

        public void MapCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
            ImageUrl = category.ImageUrl;
            CreatedBy = category.CreatedBy;
            CreatedDate = category.CreatedDate;
            UpdatedBy = category.UpdatedBy;
            UpdatedDate = category.UpdatedDate;
        }

        public Category MapCategory()
        {
            var category = new Category();
            category.Id = Id;
            category.Name = Name;
            category.Description = Description;
            category.ImageUrl = ImageUrl;
            category.CreatedBy = CreatedBy;
            category.CreatedDate = CreatedDate;
            category.UpdatedBy = UpdatedBy;
            category.UpdatedDate = UpdatedDate;

            return category;
        }
    }
}
