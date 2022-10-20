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
    }
}
