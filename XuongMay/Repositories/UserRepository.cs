using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;

namespace XuongMay.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly XuongmaybeContext _context;

        public UserRepository(XuongmaybeContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.IdRoleNavigation) // Để truy cập Role khi xác thực
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}