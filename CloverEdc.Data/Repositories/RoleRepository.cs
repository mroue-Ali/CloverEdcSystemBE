using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Role> GetByIdAsync(Guid id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> CreateAsync(RoleDto role)
    {
        var newrole = new Role
        {
            Name = role.Name
        }; 
        _context.Roles.Add(newrole);
        await _context.SaveChangesAsync();
        return newrole;
    }

    public async Task<Role> UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var role = await GetByIdAsync(id);
        if (role == null) return false;

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
    public IQueryable<Role> SearchRoles(string keyword)
    {
        return  _context.Roles.Where(x => x.Name.Contains(keyword));
    }

    public async Task<(IEnumerable<Role>, int)> GetPagedRolesAsync(Filter filter)
    {
        var query = _context.Roles.AsQueryable();
        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {    
            query = query.Where(r =>
                r.Name.Contains(keyword)
            );
             
        }    
        var totalItems = await query.CountAsync();
        var roles = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();

        return (roles, totalItems);
    }

    public async Task<Role> GetRoleByNameAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
}