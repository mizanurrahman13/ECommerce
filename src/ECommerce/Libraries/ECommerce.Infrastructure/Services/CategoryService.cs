using AutoMapper;
using ECommerce.Infrastructure.Exceptions;
using ECommerce.Infrastructure.UnitOfWorks;
using CategoryBO = ECommerce.Infrastructure.BusinessObjects.Category;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;

namespace ECommerce.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IECommerceUnitOfWork _ecommerceUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CategoryService(IECommerceUnitOfWork ecommerceUnitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _ecommerceUnitOfWork = ecommerceUnitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task CreateCategory(CategoryBO category)
        {
            var count = await _ecommerceUnitOfWork.Categories.GetCountAsync(x => x.Name == category.Name);

            if (count == 0)
            {
                var categoryEntity = _mapper.Map<CategoryEntity>(category);

                categoryEntity.CreatedBy = await _currentUserService.GetUsername();
                categoryEntity.UpdatedBy = await _currentUserService.GetUsername();

                await _ecommerceUnitOfWork.Categories.AddAsync(categoryEntity);
                await _ecommerceUnitOfWork.SaveAsync();
            }
            else
                throw new DuplicateException("Category with same name already exists");
        }

        public async Task<(int total, int displayTotal, IList<CategoryBO> records)> GetCategoryAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            List<CategoryBO> categories = new List<CategoryBO>();
            var result = await _ecommerceUnitOfWork.Categories.GetDynamicAsync(x => x.Name!.Contains(searchText),
                orderBy, null, pageIndex, pageSize, true);

            foreach (CategoryEntity entitiy in result.data)
            {
                categories.Add(_mapper.Map<CategoryBO>(entitiy));
            }
            return (result.total, result.totalDisplay, categories);
        }

        public async Task<CategoryBO> GetCategoryByIdAsync(Guid id)
        {
            var categoryEntity = await _ecommerceUnitOfWork.Categories.GetByIdAsync(id);

            if (categoryEntity is null)
                throw new InvalidOperationException("Category with this id not found");

            var category = _mapper.Map<CategoryBO>(categoryEntity);
            return category;
        }

        public CategoryBO GetCategoryById(Guid id)
        {
            var categoryEntity = _ecommerceUnitOfWork.Categories.GetById(id);

            if (categoryEntity is null)
                throw new InvalidOperationException("Category with this id not found");

            var category = _mapper.Map<CategoryBO>(categoryEntity);
            return category;
        }

        public async Task UpdateCategoryAsync(CategoryBO category)
        {
            if (category is null)
                throw new InvalidOperationException("Category must be provided to update item");

            var count = await _ecommerceUnitOfWork.Categories.IsCategoryAlreadyExists(category);

            if (count != 0)
                throw new InvalidOperationException("Category name already exists");

            var categoryEntity = await _ecommerceUnitOfWork.Categories.GetByIdAsync(category.Id);
            categoryEntity = _mapper.Map(category, categoryEntity);

            categoryEntity.CreatedBy = await _currentUserService.GetUsername();
            categoryEntity.UpdatedBy = await _currentUserService.GetUsername();

            await _ecommerceUnitOfWork.SaveAsync();

        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _ecommerceUnitOfWork.Categories.RemoveAsync(id);
            await _ecommerceUnitOfWork.SaveAsync();
        }

        public async Task<List<CategoryBO>> GetCategoriesAsync(Guid? id)
        {
            var categoriesEO = await _ecommerceUnitOfWork.Categories.GetAsync(x => x.Id == id, null);
            var categoriesBO = _mapper.Map<List<CategoryBO>>(categoriesEO);
            return categoriesBO;
        }

        public void DeleteCategory(Guid id)
        {
            _ecommerceUnitOfWork.Categories.Remove(id);
            _ecommerceUnitOfWork.Save();
        }

        public CategoryBO GetCategoryImageById(Guid Id)
        {
            var result = _ecommerceUnitOfWork.
                 Categories.Get(x => x.Id.Equals(Id),
                 string.Empty).FirstOrDefault();

            var category = _mapper.Map<CategoryBO>(result);
            return category;
        }

        public async Task<IList<CategoryBO>> GetAllAsync()
        {
            var categoryEntities = await _ecommerceUnitOfWork.Categories.GetAllAsync();

            List<CategoryBO> categories = new List<CategoryBO>();

            foreach (CategoryEntity entity in categoryEntities)
            {
                categories.Add(_mapper.Map<CategoryBO>(entity));
            }

            return categories;
        }

        public IList<CategoryBO> GetAll()
        {
            var categoryEntities = _ecommerceUnitOfWork.Categories.GetAll();

            List<CategoryBO> categories = new List<CategoryBO>();

            foreach (CategoryEntity entity in categoryEntities)
            {
                categories.Add(_mapper.Map<CategoryBO>(entity));
            }

            return categories;
        }
    }
}
