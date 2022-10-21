using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CategoryBO = ECommerce.Infrastructure.BusinessObjects.Category;

namespace ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, Guid, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<int> IsCategoryAlreadyExists(CategoryBO category)
        {
            return await GetCountAsync(x => x.Name == category.Name && x.Id != category.Id);
        }

        public virtual IList<Category> Get(Expression<Func<Category, bool>> filter, string includeProperties = "")
        {
            IQueryable<Category> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public virtual async Task<IList<Category>> GetAsync(Expression<Func<Category, bool>> filter, string includeProperties = "")
        {
            IQueryable<Category> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            //return query.ToList();
            return await EntityFrameworkQueryableExtensions.ToListAsync(query);
        }
    }
}
