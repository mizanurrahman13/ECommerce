using Autofac;
using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.Services;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class ProductRestoreModel : AdminLayoutModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime TriggeredOn { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        private IProductService? _productService;
        private IProductRestoreService _productRestoreService;

        public ProductRestoreModel()
        {

        }

        public ProductRestoreModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IProductService? productService,
            IProductRestoreService? productRestoreService,
            IMapper mapper)
           : base(userManagerAdapter, httpContextAccessor, mapper)
        {
            _productService = productService;
            _productRestoreService = productRestoreService!;
        }

        public override void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productService = _scope.Resolve<IProductService>();
            _productRestoreService = _scope.Resolve<IProductRestoreService>();
            base.Resolve(scope);
        }

        public void MakeTrash(Guid productId)
        {
            var product = _productService!.GetProductById(productId);
            product.Featured = false;//removed from feature
            product.ActiveStatus = false;//removed from feed
            product.DeleteQueue = true;//moved to delete queue

            var trashedProduct = new ProductDelete();
            trashedProduct.ProductId = product.Id;//product id assigned
            trashedProduct.TriggeredOn = DateTime.UtcNow;//delete triggered time

            //edited as it moved to trash table
            _productService.UpdateProduct(product);
            _productRestoreService.Add(trashedProduct);//added to trash table
        }

        public void Restore(Guid productId)
        {
            var product = _productService!.GetProductById(productId);
            product.Featured = false;// reamin removed from feature after restore
            product.ActiveStatus = false;// reamin removed from feed after restore
            product.DeleteQueue = false;//moved from delete queue

            //edited as it moved from trash table
            _productService.UpdateProduct(product);

            var trashedProduct = _productRestoreService.GetTrashByProductId(productId);
            _productRestoreService.Remove(trashedProduct.Id);//removed from trash table
        }

        public void ForceDelete(Guid productId)
        {
            var product = _productService!.GetProductById(productId);
            var trashedProduct = _productRestoreService.GetTrashByProductId(productId);

            _productService!.DeleteProduct(product.Id);
            _productRestoreService.Remove(trashedProduct.Id);
        }
    }
}
