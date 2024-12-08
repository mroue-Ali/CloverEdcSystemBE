using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface  IRoleService
{
    
    Task<Role> GetRoleByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> CreateRoleAsync(RoleDto role);
    Task<Role> UpdateRoleAsync(Guid id, RoleDto role);
    Task<bool> DeleteRoleAsync(Guid id);
    IEnumerable<Role> SearchRolesAsync(string keyword);
    Task<(IEnumerable<Role>, int)> GetPagedRolesAsync(Filter filter);
}
