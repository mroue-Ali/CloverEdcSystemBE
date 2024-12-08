using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    private readonly AuthHelper _authHelper;

    public RoleService( IRoleRepository roleRepository, AuthHelper authHelper)
    {
        _authHelper = authHelper;
        _roleRepository = roleRepository;
    }
    public async Task<Role> GetRoleByIdAsync(Guid id)
    {
        return await _roleRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _roleRepository.GetAllAsync();
    }

    public async Task<Role> CreateRoleAsync(RoleDto role)
    {
        return await _roleRepository.CreateAsync(role);
    }

    public async Task<Role> UpdateRoleAsync(Guid id, RoleDto role)
    {
        var existingRole = await _roleRepository.GetByIdAsync(id);
        if (existingRole == null) throw new KeyNotFoundException("Role not found");

        existingRole.Name = role.Name;
        return await _roleRepository.UpdateAsync(existingRole);
    }

    public async Task<bool> DeleteRoleAsync(Guid id)
    {
        return await _roleRepository.DeleteAsync(id);
    }
    public IEnumerable<Role> SearchRolesAsync(string keyword)
    {
        return  _roleRepository.SearchRoles(keyword);
    }
    public async Task<(IEnumerable<Role>,int)> GetPagedRolesAsync(Filter filter)
    {
        var (roles, totalItems) = await _roleRepository.GetPagedRolesAsync(filter);

       return (roles, totalItems);
    }

    
}