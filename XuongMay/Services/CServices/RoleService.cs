using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.IServices;

namespace XuongMay.Services.CServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponse?> CreateRoleAsync(CreateRoleRequest request)
        {
            var existingRole = await _roleRepository.GetRoleByNameAsync(request.Name);
            if (existingRole != null)
            {
                throw new InvalidOperationException("Vai trò đã tồn tại.");
            }

            var role = new Role
            {
                IdRole = Guid.NewGuid(),
                Name = request.Name,
                CreateAt = DateTime.UtcNow
            };

            await _roleRepository.AddRoleAsync(role);

            return new RoleResponse
            {
                Id = role.IdRole.ToString(),
                Name = role.Name
            };
        }

        public async Task<RoleResponse?> GetRoleByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return null;

            return new RoleResponse
            {
                Id = role.IdRole.ToString(),
                Name = role.Name
            };
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(role => new RoleResponse
            {
                Id = role.IdRole.ToString(),
                Name = role.Name
            });
        }

        public async Task<RoleResponse?> UpdateRoleAsync(Guid id, UpdateRoleRequest request)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return null;
            }

            role.Name = request.Name ?? role.Name;

            await _roleRepository.UpdateRoleAsync(role);

            return new RoleResponse
            {
                Id = role.IdRole.ToString(),
                Name = role.Name
            };
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return false;

            await _roleRepository.DeleteRoleAsync(role);
            return true;
        }
    }
}
