using AutoMapper;
using DevSkill.Core.Utilities;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Infrastructure.UnitOfWorks;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;
using ProductImageBO = ECommerce.Infrastructure.BusinessObjects.ProductImage;

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
            var count = await _ecommerceUnitOfWork.Products.GetCountAsync(x => x.Name == product.Name);

            if (count == 0)
            {
                var productEntity = _mapper.Map<ProductEntity>(product);

                var id = IdentityGenerator.NewSequentialGuid();
                productEntity.Id = id;

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

        public async Task<(int total, int totalDisplay, IList<ProductBO> products)> GetActiveProductsAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ecommerceUnitOfWork.Products.GetDynamic(x => x.Name.Contains(searchText) && !x.DeleteQueue,
                orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true);

            List<ProductBO> products = new List<ProductBO>();
            foreach (ProductEntity product in result.data)
            {
                products.Add(_mapper.Map<ProductBO>(product));
            }

            return (result.total, result.totalDisplay, products);
        }

        public (int total, int totalDisplay, IList<ProductBO> products) GetActiveProducts(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ecommerceUnitOfWork.Products.GetDynamic(x => x.Name.Contains(searchText) && !x.DeleteQueue,
                orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true);

            List<ProductBO> products = new List<ProductBO>();
            foreach (ProductEntity product in result.data)
            {
                products.Add(_mapper.Map<ProductBO>(product));
            }

            return (result.total, result.totalDisplay, products);
        }

        public async Task<ProductBO> GetProductByIdAsync(Guid id)
        {
            var productEntity = await _ecommerceUnitOfWork.Products.GetByIdAsync(id);

            if (productEntity is null)
                throw new InvalidOperationException("Product with this id not found");

            var product = _mapper.Map<ProductBO>(productEntity);
            return product;
        }

        public ProductBO GetProductById(Guid id)
        {
            var productEntity = _ecommerceUnitOfWork.Products.GetById(id);

            if (productEntity is null)
                throw new InvalidOperationException("Product with this id not found");

            var product = _mapper.Map<ProductBO>(productEntity);
            return product;
        }

        public async Task UpdateProductAsync(ProductBO product)
        {
            if (product is null)
                throw new InvalidOperationException("Product must be provided to update item");

            var count = await _ecommerceUnitOfWork.Products.IsProductAlreadyExists(product);

            if (count != 0)
                throw new InvalidOperationException("Product name already exists");

            var productEntity = _ecommerceUnitOfWork.Products.Get(x => x.Id.Equals(product.Id),
                                    "ProductImages").FirstOrDefault();

            productEntity.ProductImages = null;
            productEntity = _mapper.Map(product, productEntity);

            productEntity.CreatedBy = await _currentUserService.GetUsername();
            productEntity.UpdatedBy = await _currentUserService.GetUsername();

            await _ecommerceUnitOfWork.SaveAsync();
        }

        public void UpdateProduct(ProductBO product)
        {
            if (product is null)
                throw new InvalidOperationException("Product must be provided to update item");

            var count = _ecommerceUnitOfWork.Products.IsProductAlreadyExist(product);

            if (count != 0)
                throw new InvalidOperationException("Product name already exists");

            var productEntity = _ecommerceUnitOfWork.Products.Get(x => x.Id.Equals(product.Id),
                                    string.Empty).FirstOrDefault();

            productEntity = _mapper.Map(product, productEntity);

            productEntity.CreatedBy = _currentUserService.GetUsernames();
            productEntity.UpdatedBy = _currentUserService.GetUsernames();

            _ecommerceUnitOfWork.Save();
        }

        public ProductBO GetProductImageById(Guid Id)
        {
            var result = _ecommerceUnitOfWork.
                 Products.Get(x => x.Id.Equals(Id),
                 "ProductImages").FirstOrDefault();

            var product = _mapper.Map<ProductBO>(result);

            return product;
        }

        public void ChangeVisibility(Guid id)
        {
            var productEntity = _ecommerceUnitOfWork.Products.GetById(id);

            productEntity.ActiveStatus = (productEntity.ActiveStatus) ? false : true;
            _ecommerceUnitOfWork.Save();
        }

        public void ChangeFeatureProperty(Guid id)
        {
            var productEntity = _ecommerceUnitOfWork.Products.GetById(id);

            productEntity.Featured = (productEntity.Featured) ? false : true;
            _ecommerceUnitOfWork.Save();
        }

        public (int total, int totalDisplay, IList<ProductBO> trashedProducts) GetTrashedProducts(
                    int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _ecommerceUnitOfWork.Products.GetDynamic(x => x.DeleteQueue,
                orderBy, "ProductImages,ProductCategories,ProductInventory", pageIndex, pageSize, true);


            IList<ProductBO> trashedProducts = new List<ProductBO>();
            foreach (var product in result.data)
            {
                trashedProducts.Add(_mapper.Map<ProductBO>(product));
            }

            return (result.total, result.totalDisplay, trashedProducts);
        }

        public void DeleteProduct(Guid id)
        {
            _ecommerceUnitOfWork.Products.Remove(id);
            _ecommerceUnitOfWork.Save();
        }
    }
}
