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
    }
}
