using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProductDeleteEntity = ECommerce.Infrastructure.Entities.ProductDelete;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRestoreRepository : Repository<ProductDeleteEntity, Guid, ApplicationDbContext>, IProductRestoreRepository
    {
        public ProductRestoreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual IList<ProductDeleteEntity> Get(Expression<Func<ProductDeleteEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<ProductDeleteEntity> query = _dbSet;

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
    }
}
