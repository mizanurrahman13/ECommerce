using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, Guid, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext applicationDbContext)
            : base((ApplicationDbContext)applicationDbContext)
        {

        }
    }
}
