using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<List<Category>> GetAllAsync();
    }
}
    