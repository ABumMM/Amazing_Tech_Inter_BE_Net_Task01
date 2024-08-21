using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(Role role);
        Task<Role?> GetRoleByIdAsync(Guid id);
        Task<Role?> GetRoleByNameAsync(string name);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}
