using ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Infrastructure.Services
{
    public interface IProductService
    {
        Task CreateProduct(Product product);
        Task<(int total, int displayTotal, IList<Product> records)>
            GetProductAsync(int pageIndex,
            int pageSize,
            string searchText,
            string orderBy);
        Task<(int total, int totalDisplay, IList<Product> products)> GetActiveProductsAsync(int pageIndex, int pageSize, string searchText, string orderBy);
        (int total, int totalDisplay, IList<Product> products) GetActiveProducts(int pageIndex, int pageSize, string searchText, string orderBy);
        Task<Product> GetProductByIdAsync(Guid id);
        Product GetProductById(Guid id);
        Task UpdateProductAsync(Product product);
        Product GetProductImageById(Guid Id);
        void ChangeVisibility(Guid id);
        void ChangeFeatureProperty(Guid id);
    }
}
