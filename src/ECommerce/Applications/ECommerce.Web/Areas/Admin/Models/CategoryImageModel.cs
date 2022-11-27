using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class CategoryImageModel
    {

        private ICategoryService _categoryService;
        private ILifetimeScope _scope;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public String URL { get; set; }
        public long Size { get; set; }

        public CategoryImageModel()
        {

        }

        public CategoryImageModel(ICategoryService categoryService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
            _mapper = _scope.Resolve<IMapper>();
        }
        public List<CategoryImageModel> GetImageByCategoryId(Guid categoryId)
        {
            var category = _categoryService.GetCategoryImageById(categoryId);
            var image = new List<CategoryImageModel>();
            long size = 0;
            if (category != null)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var imagePhysicalUrl = currentDirectory + "//wwwroot/" + category.ImageUrl;
                FileInfo fi = new FileInfo(imagePhysicalUrl);
                if (fi.Exists)
                {
                    size = fi.Length;
                }

                image.Add(new CategoryImageModel() { URL = category.ImageUrl!, Size = size });
            }
            else
            {
                image.Add(new CategoryImageModel() { URL = "No image Found", Size = 0 });
            }

            return image;
        }
    }
}
