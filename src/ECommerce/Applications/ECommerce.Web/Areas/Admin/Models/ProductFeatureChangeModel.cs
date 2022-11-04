using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductFeatureChangeModel : AdminLayoutModel
    {
        private IProductService? _productService;
        public ProductFeatureChangeModel()
        {

        }

        public ProductFeatureChangeModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
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

        public void ChangeFeatureProperty(Guid id)
        {
            _productService!.ChangeFeatureProperty(id);
        }
    }
}
