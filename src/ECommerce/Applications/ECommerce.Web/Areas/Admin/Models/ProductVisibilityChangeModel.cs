using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using Org.BouncyCastle.Security;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductVisibilityChangeModel : AdminLayoutModel
    {
        private IProductService? _productService;
        public ProductVisibilityChangeModel()
        {

        }

        public ProductVisibilityChangeModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
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

        public void ChangeVisibility(Guid id)
        {
            if (id == Guid.Empty)
                throw new InvalidParameterException("Product id can not be empty.");

            var product = _productService!.GetProductById(id);

            if (product == null)
                throw new InvalidParameterException("Product cann't be null.");

            product.Featured = false;//for unpublishing product, it's also will remove from feature

            //edited as it removed from feature
            _productService!.UpdateProduct(product);
            _productService.ChangeVisibility(id);
        }
    }
}
