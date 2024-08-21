using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IRoleService
    {
        Task<RoleResponse?> CreateRoleAsync(CreateRoleRequest request);
        Task<RoleResponse?> GetRoleByIdAsync(Guid id);
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync();
        Task<RoleResponse?> UpdateRoleAsync(Guid id, UpdateRoleRequest request);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
