using XuongMay.Entity;
using Microsoft.EntityFrameworkCore;

namespace XuongMay.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleByNameAsync(string roleName);
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly XuongmaybeContext _context;

        public RoleRepository(XuongmaybeContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
