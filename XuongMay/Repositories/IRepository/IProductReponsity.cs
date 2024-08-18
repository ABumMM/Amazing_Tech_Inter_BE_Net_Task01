using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface IProductReponsity
    {
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<List<Product>> GetAllAsync();
    }
}
