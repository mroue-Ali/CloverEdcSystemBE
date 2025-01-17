using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class PiRepository : BaseRepository<Pi>, IPiRepository
{
    private readonly ApplicationDbContext _context;

    public PiRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Pi> GetByIdAsync(Guid id)
    {
        return await _context.Pis.FindAsync(id);
    }

    public async Task<IEnumerable<Pi>> GetAllAsync()
    {
        return await _context.Pis.ToListAsync();
    }

    public async Task<Pi> CreateAsync(PiDto pi)
    {
        var newPi = new Pi
        {
            UserId = pi.UserId ?? Guid.Empty,
        };
        _context.Pis.Add(newPi);
        await _context.SaveChangesAsync();
        return newPi;
    }

    public async Task<Pi> UpdateAsync(Pi pi)
    {
        _context.Pis.Update(pi);
        await _context.SaveChangesAsync();
        return pi;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var pi = await GetByIdAsync(id);
        if (pi == null) return false;

        _context.Pis.Remove(pi);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Pi>> GetPisByStudyIdAsync(Guid studyId)
    {
        return await _context.Pis
            .Include(x => x.User)
            // .Include(x=>x.Sites)
            .Where(p => p.User.StudyId == studyId)
            .ToListAsync();
    }

    public async Task<(IEnumerable<Pi>, int)> GetPisByStudyIdAsync(Guid studyId, Filter filter)
    {
        var query = _context.Pis.Include(x => x.User).Where(x => x.User.StudyId == studyId).AsQueryable();
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
        var sitesDto = items.Select(x => new Pi
        {
            Id = x.Id,
            User = new User
            {
                UserName = x.User.UserName,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Email = x.User.Email
            },
            SitesStr =  string.Join(", ", _context.Sites
                .Where(r => r.PiId == x.Id)
                .Select(r => r.Name)),
            Sites = _context.Sites
                .Where(r => r.PiId == x.Id)
                .ToList()
        });
        return (sitesDto, totalItems);
    }
}