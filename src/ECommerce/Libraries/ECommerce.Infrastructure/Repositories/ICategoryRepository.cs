using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;
using CategoryBO = ECommerce.Infrastructure.BusinessObjects.Category;

namespace ECommerce.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity, Guid, ApplicationDbContext>
    {
        Task<int> IsCategoryAlreadyExists(CategoryBO category);
    }
}
