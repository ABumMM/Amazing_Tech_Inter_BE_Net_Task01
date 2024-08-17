using XuongMay.Entity;

namespace XuongMay.Repositories.IRepository
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleByNameAsync(string roleName);
    }
}
