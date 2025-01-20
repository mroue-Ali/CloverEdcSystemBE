using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByRefreshTokenAsync(Guid refreshToken)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
    }

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        // return await _context.Users.Include(u => u.Role).ToListAsync();
        return await _context.Users.Include(x => x.Role).ToListAsync();
    }

    public async Task<(IEnumerable<User>, int)> GetFilteredUsers(Filter filter)
    {
        var query = _context.Users
            .Include(u => u.Role) // Include Role for eager loading
            .AsQueryable(); 

        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(u =>
                    u.UserName.Contains(keyword) ||
                    u.Email.Contains(keyword) ||
                    u.Role.Name.Contains(keyword) // Search in Role.Name
            );
        }

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();
        
        // var query = _context.Users.AsQueryable();
        // var keyword = filter.keyword;
        // if (!string.IsNullOrEmpty(keyword))
        // {
        //     query = query.Where(r =>
        //         r.UserName.Contains(keyword) ||
        //         r.Email.Contains(keyword)
        //     ); // Adjust field as per your needs
        //     //I want to saerch where the user.role.name contains the keyword
        // }
        //
        // var totalItems = await query.CountAsync();
        // var items = await query
        //     .Skip((filter.offset) * filter.size)
        //     .Take(filter.size)
        //     .Include(x => x.Role)
        //     .ToListAsync();

        return (items, totalItems);
    }
    
  
}