using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role> GetByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role> CreateAsync(RoleDto role);
    Task<Role> UpdateAsync(Role role);
    Task<bool> DeleteAsync(Guid id);
    IQueryable<Role> SearchRoles(string keyword);
    Task<(IEnumerable<Role>, int)> GetPagedRolesAsync(Filter filter);
    Task<Role> GetRoleByNameAsync(string name);
}