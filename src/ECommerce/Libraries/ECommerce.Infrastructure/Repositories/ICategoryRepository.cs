using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid, ApplicationDbContext>
    {
    }
}
