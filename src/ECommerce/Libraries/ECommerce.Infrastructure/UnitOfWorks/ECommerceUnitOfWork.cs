using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Infrastructure.UnitOfWorks
{
    public class ECommerceUnitOfWork : UnitOfWork, IECommerceUnitOfWork
    {
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }

        public ECommerceUnitOfWork(ApplicationDbContext applicationDbContext,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
            : base(applicationDbContext)
        {

            Categories = categoryRepository;
            Products = productRepository;
        }
    }
}
