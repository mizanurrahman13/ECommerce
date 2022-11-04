using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using System.Linq.Expressions;
using ProductDeleteEntity = ECommerce.Infrastructure.Entities.ProductDelete;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IProductRestoreRepository : IRepository<ProductDeleteEntity, Guid, ApplicationDbContext>
    {
        IList<ProductDeleteEntity> Get(Expression<Func<ProductDeleteEntity, bool>> filter, string includeProperties = "");
    }
}
