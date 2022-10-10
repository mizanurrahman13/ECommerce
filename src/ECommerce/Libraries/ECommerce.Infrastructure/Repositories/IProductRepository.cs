using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity, Guid, ApplicationDbContext>
    {
        Task<int> IsProductAlreadyExists(ProductBO product);
        IList<ProductEntity> Get(Expression<Func<ProductEntity, bool>> filter, string includeProperties = "");
    }
}
