using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
