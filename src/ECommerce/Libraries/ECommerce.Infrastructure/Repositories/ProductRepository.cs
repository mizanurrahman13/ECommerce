using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProductBO = ECommerce.Infrastructure.BusinessObjects.Product;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<int> IsProductAlreadyExists(ProductBO product)
        {
            return await GetCountAsync(x => x.Name == product.Name && x.Id != product.Id);
        }

        public virtual IList<Product> Get(Expression<Func<Product, bool>> filter, string includeProperties = "")
        {
            IQueryable<Product> query = _dbSet;

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
