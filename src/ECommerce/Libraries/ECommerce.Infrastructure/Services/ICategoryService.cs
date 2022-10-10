using ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(Category category);
        Task<(int total, int displayTotal, IList<Category> records)> 
            GetCategoryAsync(int pageIndex,
            int pageSize,
            string searchText,
            string orderBy);
        Task DeleteCategoryAsync(Guid id);
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task UpdateCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync(Guid? id);
        void DeleteCategory(Guid id);
        Category GetCategoryImageById(Guid Id);
    }
}
