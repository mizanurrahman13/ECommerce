using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductEditModel : AdminLayoutModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(100, ErrorMessage = "Name should be less than 100 letters")]
        public string Name { get; set; }

        [Required, StringLength(5000, ErrorMessage = "Description should be less than 5000 characters")]
        public string Description { get; set; }

        [Range(10, 5000000, ErrorMessage = "Price should be between 0 and 5000000")]

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal DiscountedPrice { get; set; }
        public string? Status { get; set; }
        public bool ActiveStatus { get; set; }
        public bool Featured { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public string? ImageUrlsParam { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        private IProductService? _productService;
        public ProductEditModel()
        {

        }

        public ProductEditModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IProductService productService,
            IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _productService = productService;
        }

        public override void Resolve(ILifetimeScope lifetimescope)
        {
            _scope = lifetimescope;
            _productService = _scope.Resolve<IProductService>();
            base.Resolve(lifetimescope);
        }

        public async Task GetProduct(Guid id)
        {
            var product = await _productService!.GetProductByIdAsync(id);

            //MapProduct(product);
            _mapper!.Map(product, this);
        }

        public async Task UpdateProductAsync(IList<string> imageUrls)
        {
            var product = _mapper!.Map<Product>(this);
            //var product = MapProduct();

            if (this.Status == "Active")
                product.ActiveStatus = true;
            else
                product.ActiveStatus = false;


            product.ProductImages = new List<ProductImage>();

            foreach (var images in imageUrls)
            {
                product.ProductImages?.Add(new ProductImage
                {
                    Url = images,
                });
            }

            await _productService!.UpdateProductAsync(product);
        }
    }
}
