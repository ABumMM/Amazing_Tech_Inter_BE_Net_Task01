using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
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
        // lấy tất cả User
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        // lấy User theo id
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        // xóa người dùng
        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}