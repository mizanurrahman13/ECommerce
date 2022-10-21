using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;
using CategoryBO = ECommerce.Infrastructure.BusinessObjects.Category;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity, Guid, ApplicationDbContext>
    {
        Task<int> IsCategoryAlreadyExists(CategoryBO category);
        IList<CategoryEntity> Get(Expression<Func<CategoryEntity, bool>> filter, string includeProperties = "");
        Task<IList<CategoryEntity>> GetAsync(Expression<Func<CategoryEntity, bool>> filter, string includeProperties = "");
    }
}
