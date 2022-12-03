using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Infrastructure.UnitOfWorks;
using Org.BouncyCastle.Security;
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

            if (entity == null)
                throw new InvalidParameterException("ProductDelete entity can't be null");

            //_eCommerceUnitOfWork.ProductRestores.AddAsync(entity);
            //_eCommerceUnitOfWork.SaveAsync();
            _eCommerceUnitOfWork.ProductRestores.Add(entity);
            _eCommerceUnitOfWork.Save();

        }
        public void Remove(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new InvalidParameterException("ProductDelete Id can't be null");

            //_eCommerceUnitOfWork.ProductRestores.RemoveAsync(Id);
            //_eCommerceUnitOfWork.SaveAsync();
            _eCommerceUnitOfWork.ProductRestores.Remove(Id);
            _eCommerceUnitOfWork.Save();
        }
        public ProductDelete GetTrashByProductId(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new InvalidParameterException("ProductDelete Id can't be null");

            var entity = _eCommerceUnitOfWork.ProductRestores
                .Get(x => x.ProductId == productId, string.Empty).FirstOrDefault();

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
