using ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Infrastructure.Services
{
    public interface IProductRestoreService
    {
        void Add(ProductDelete trashProduct);
        void Remove(Guid Id);
        ProductDelete GetTrashByProductId(Guid ProductId);
        IList<ProductDelete> GetTrashedProducts();
    }
}
