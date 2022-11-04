using DevSkill.Data;
using ECommerce.Infrastructure.DbContexts;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Infrastructure.UnitOfWorks
{
    public class ECommerceUnitOfWork : UnitOfWork, IECommerceUnitOfWork
    {
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductRestoreRepository ProductRestores { get; private set; }

        public ECommerceUnitOfWork(ApplicationDbContext applicationDbContext,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductRestoreRepository productRestores)
            : base(applicationDbContext)
        {

            Categories = categoryRepository;
            Products = productRepository;
            ProductRestores = productRestores;
        }
    }
}
