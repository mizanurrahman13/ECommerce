using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;
using CategoryBO = ECommerce.Infrastructure.BusinessObjects.Category;

namespace ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, Guid, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext applicationDbContext)
            : base((ApplicationDbContext)applicationDbContext)
        {
        }

        public async Task<int> IsCategoryAlreadyExists(CategoryBO category)
        {
            return await GetCountAsync(x => x.Name == category.Name && x.Id != category.Id);
        }
    }
}
