using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role
{
    public interface IRoleService
    {
        Task<string> CreateAsync(CreateRoleRequest request);
        Task<string> UpdateAsync(UpdateRoleRequest request);
        Task<string> DeleteAsync(string id);
        Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequest request);
        Task<bool> DoesItExistsAsync(string name);
        Task<List<RoleResponse>> GetAllAsync(CancellationToken ct);
        Task<RoleResponse> GetByIdAsync(string id, CancellationToken ct);
        Task<RoleResponse> GetRoleWithPermissionsAsync(string id, CancellationToken ct);
    }
}
