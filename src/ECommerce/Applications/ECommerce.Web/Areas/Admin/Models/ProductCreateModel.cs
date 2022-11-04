using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using System.ComponentModel.DataAnnotations;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;
using ProductCategoryBO = ECommerce.Infrastructure.BusinessObjects.ProductCategory;
using ProductImageBO = ECommerce.Infrastructure.BusinessObjects.ProductImage;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductCreateModel : AdminLayoutModel
    {
        [Required, StringLength(100, ErrorMessage = "Name should be less than 100 letters")]
        public string Name { get; set; }

        [Required, StringLength(5000, ErrorMessage = "Description should be less than 5000 characters")]
        public string Description { get; set; }

        [Range(10, 50000000, ErrorMessage = "Price should be between 10 and 50000000")]

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public string? Status { get; set; }

        public string? ImageUrlsParam { get; set; }

        public string? CategoriesId { get; set; }

        public List<ProductImageBO>? ProductImages { get; set; }

        public bool ActiveStatus { get; set; }
        public List<ProductCategoryBO>? ProductCategories { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        private IProductService? _productService;

        public ProductCreateModel()
        {

        }

        public ProductCreateModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IProductService productService,
            IMapper mapper)
           : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _productService = productService;
        }

        public override void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productService = _scope.Resolve<IProductService>();
            base.Resolve(scope);
        }

        public async Task CreateProduct(IList<string> imageUrls, string[] categoriesId)
        {
            await GetUserInfoAsync();

            var product = _mapper!.Map<ProductBO>(this);
            if (this.Status == "Active")
                product.ActiveStatus = true;
            else
                product.ActiveStatus = false;

            product.ProductImages = new List<ProductImageBO>();
            product.ProductCategories = new List<ProductCategoryBO>();
            foreach (var images in imageUrls)
            {
                product.ProductImages?.Add(new ProductImageBO
                {
                    Url = images,
                });
            }

            foreach (var id in categoriesId)
            {
                if (id == "default")
                {
                    product.ProductCategories?.Add(new ProductCategoryBO
                    {
                        CategoryId = Guid.Parse("F23B443B-2185-4DD7-9952-8A91185E5244")
                    });
                }
                else
                {
                    product.ProductCategories?.Add(new ProductCategoryBO
                    {
                        CategoryId = new Guid(id)
                    });
                }
            }

            if (product.DiscountedPrice > product.UnitPrice)
            {
                throw new Exception("Discounted price cant be greater than unit price");
            }
            else
                await _productService!.CreateProduct(product);
        }
    }
}
