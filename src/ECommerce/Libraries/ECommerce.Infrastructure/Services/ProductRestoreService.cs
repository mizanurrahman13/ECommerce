using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.UnitOfWorks;
using ProductDeleteEntity = ECommerce.Infrastructure.Entities.ProductDelete;

namespace ECommerce.Infrastructure.Services
{
    public class ProductRestoreService : IProductRestoreService
    {
        private readonly IECommerceUnitOfWork _eCommerceUnitOfWork;
        private readonly IMapper _mapper;

        public ProductRestoreService(IECommerceUnitOfWork eCommerceUnitOfWork, 
            IMapper mapper)
        {
            _eCommerceUnitOfWork = eCommerceUnitOfWork;
            _mapper = mapper;
        }

        public void Add(ProductDelete trashProduct)
        {
            //move product to delete queue, worker service will delete after 1 day
            var entity = _mapper.Map<ProductDeleteEntity>(trashProduct);

            //_eCommerceUnitOfWork.ProductRestores.AddAsync(entity);
            //_eCommerceUnitOfWork.SaveAsync();
            _eCommerceUnitOfWork.ProductRestores.Add(entity);
            _eCommerceUnitOfWork.Save();

        }
        public void Remove(Guid Id)
        {
            //_eCommerceUnitOfWork.ProductRestores.RemoveAsync(Id);
            //_eCommerceUnitOfWork.SaveAsync();
            _eCommerceUnitOfWork.ProductRestores.Remove(Id);
            _eCommerceUnitOfWork.Save();
        }
        public ProductDelete GetTrashByProductId(Guid ProductId)
        {
            var entity = _eCommerceUnitOfWork.ProductRestores
                .Get(x => x.ProductId == ProductId, string.Empty).FirstOrDefault();
            return _mapper.Map<ProductDelete>(entity);
        }
        public IList<ProductDelete> GetTrashedProducts()
        {
            var entities = _eCommerceUnitOfWork.ProductRestores.GetAll();
            var trasedProduct = new List<ProductDelete>();
            foreach (var entity in entities)
                trasedProduct.Add(_mapper.Map<ProductDelete>(entity));
            
            return trasedProduct;
        }
    }
}
