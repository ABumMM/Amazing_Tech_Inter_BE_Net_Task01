using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();  // Lấy tất cả người dùng
        Task<User?> GetUserByIdAsync(Guid id);       // Lấy người dùng theo ID
        Task UpdateUserAsync(User user);    // Sửa người dùng
        Task DeleteUserAsync(User user);
    }
}
