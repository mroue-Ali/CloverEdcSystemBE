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
}