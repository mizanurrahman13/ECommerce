using DevSkill.Data;
using ECommerce.Infrastructure.Repositories;

namespace ECommerce.Infrastructure.UnitOfWorks
{
    public interface IECommerceUnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IProductRestoreRepository ProductRestores { get; }
    }
}
