using XuongMay.Entity;
using Microsoft.EntityFrameworkCore;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
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
