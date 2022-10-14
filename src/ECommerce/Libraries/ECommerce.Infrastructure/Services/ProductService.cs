using AutoMapper;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Infrastructure.UnitOfWorks;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;

namespace ECommerce.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IECommerceUnitOfWork _ecommerceUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProductService(IECommerceUnitOfWork ecommerceUnitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _ecommerceUnitOfWork = ecommerceUnitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task CreateProduct(ProductBO product)
        {
            var count = await _ecommerceUnitOfWork.Categories.GetCountAsync(x => x.Name == product.Name);

            if (count == 0)
            {
                var productEntity = _mapper.Map<ProductEntity>(product);

                productEntity.CreatedBy = await _currentUserService.GetUsername();
                productEntity.UpdatedBy = await _currentUserService.GetUsername();

                await _ecommerceUnitOfWork.Products.AddAsync(productEntity);
                await _ecommerceUnitOfWork.SaveAsync();
            }
            else
                throw new DuplicateException("Product with same name already exists");
        }

        public async Task<(int total, int displayTotal, IList<ProductBO> records)> GetProductAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            List<ProductBO> products = new List<ProductBO>();
            var result = await _ecommerceUnitOfWork.Products.GetDynamicAsync(x => x.Name!.Contains(searchText),
                orderBy, null, pageIndex, pageSize, true);

            foreach (ProductEntity entitiy in result.data)
            {
                products.Add(_mapper.Map<ProductBO>(entitiy));
            }
            return (result.total, result.totalDisplay, products);
        }

        public async Task<(int total, int totalDisplay, IList<ProductBO> products)> GetActiveProducts(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ecommerceUnitOfWork.Products.GetDynamic(x => x.Name.Contains(searchText),
                orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true);

            List<ProductBO> products = new List<ProductBO>();
            foreach (ProductEntity product in result.data)
            {
                products.Add(_mapper.Map<ProductBO>(product));
            }

            return (result.total, result.totalDisplay, products);
        }
    }
}
