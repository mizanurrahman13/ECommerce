using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using System.Linq.Expressions;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity, Guid, ApplicationDbContext>
    {
        Task<int> IsProductAlreadyExists(ProductBO product);
        int IsProductAlreadyExist(ProductBO product);
        IList<ProductEntity> Get(Expression<Func<ProductEntity, bool>> filter, string includeProperties = "");
        (IList<ProductEntity> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<ProductEntity, bool>> filter = null!,
            string orderBy = null!,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        Task<IList<ProductEntity>> GetAsync(Expression<Func<ProductEntity, bool>> filter, string includeProperties = "");
    }
}
