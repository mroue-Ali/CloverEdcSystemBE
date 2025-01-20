using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class DmRepository : BaseRepository<Dm>, IDmRepository
{
    private readonly ApplicationDbContext _context;

    public DmRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Dm> GetByIdAsync(Guid id)
    {
        return await _context.Dms.FindAsync(id);
    }

    public async Task<IEnumerable<Dm>> GetAllAsync()
    {
        return await _context.Dms.ToListAsync();
    }

    public async Task<Dm> CreateAsync(DmDto dm)
    {
        var newDm = new Dm
        {
            UserId = dm.UserId?? Guid.Empty
        };
        _context.Dms.Add(newDm);
        await _context.SaveChangesAsync();
        return newDm;
    }

    public async Task<Dm> UpdateAsync(Dm dm)
    {
        _context.Dms.Update(dm);
        await _context.SaveChangesAsync();
        return dm;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var dm = await GetByIdAsync(id);
        if (dm == null) return false;

        _context.Dms.Remove(dm);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<IEnumerable<Dm>> GetDmsByStudyIdAsync(Guid studyId)
    {
        return await _context.Dms.Include(x=>x.User).Where(dm => dm.User.StudyId == studyId).ToListAsync();
    }
    public async Task<(IEnumerable<Dm>, int)> GetDmsByStudyIdAsync(Guid studyId, Filter filter)
    {
        var query = _context.Dms.Include(x => x.User).Where(x => x.User.StudyId == studyId).AsQueryable();
        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query
                .Where(r => (r.User.FirstName.ToLower().Contains(keyword.ToLower()))||
                            (r.User.LastName.ToLower().Contains(keyword.ToLower()))||
                            (r.User.UserName.ToLower().Contains(keyword.ToLower())));
        }

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();
        var itemsDto = items.Select(x => new Dm
        {
            Id = x.Id,
            User = new User
            {
                UserName = x.User.UserName,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Email = x.User.Email
            },
        });
        return (itemsDto, totalItems);
    }

}