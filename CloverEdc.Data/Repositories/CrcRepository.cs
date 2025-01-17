using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrcRepository : BaseRepository<Crc>, ICrcRepository
{
    private readonly ApplicationDbContext _context;

    public CrcRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Crc> GetByIdAsync(Guid id)
    {
        return await _context.Crcs.FindAsync(id);
    }

    public async Task<IEnumerable<Crc>> GetAllAsync()
    {
        return await _context.Crcs.ToListAsync();
    }

    public async Task<Crc> CreateAsync(CrcDto crc)
    {
        var newCrc = new Crc
        {
            UserId = crc.UserId??Guid.Empty,
        };
        _context.Crcs.Add(newCrc);
        await _context.SaveChangesAsync();
        return newCrc;
    }

    public async Task<Crc> UpdateAsync(Crc crc)
    {
        _context.Crcs.Update(crc);
        await _context.SaveChangesAsync();
        return crc;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crc = await GetByIdAsync(id);
        if (crc == null) return false;

        _context.Crcs.Remove(crc);
        await _context.SaveChangesAsync();
        return true;
        
    }
    
    public async Task<IEnumerable<Crc>> GetCrcsByStudyIdAsync(Guid studyId)
    {
        var crcs = await _context.Crcs
            .Include(c => c.User)
            .Where(c => c.User.StudyId == studyId)
            .ToListAsync();
      
        return crcs;
    }
    
    public async Task<(IEnumerable<Crc>, int)> GetCrcsByStudyIdAsync(Guid studyId, Filter filter)
    {
        var query = _context.Crcs.Include(x => x.User).Where(x => x.User.StudyId == studyId).AsQueryable();
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
        var sitesDto = items.Select(x => new Crc
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
        return (sitesDto, totalItems);
    }

}