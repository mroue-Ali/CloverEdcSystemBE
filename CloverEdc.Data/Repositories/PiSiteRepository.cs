using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class PiSiteRepository : BaseRepository<PiSite>, IPiSiteRepository
{
    private readonly ApplicationDbContext _context;

    public PiSiteRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PiSite> GetByIdAsync(Guid id)
    {
        return await _context.PiSites.FindAsync(id);
    }

    public async Task<IEnumerable<PiSite>> GetAllAsync()
    {
        return await _context.PiSites.ToListAsync();
    }

    public async Task<PiSite> CreateAsync(PiSiteDto crcsite)
    {
        var newCrcSite = new PiSite
        {
            PiId = crcsite.PiId,
            SiteId = crcsite.SiteId
        };
        _context.PiSites.Add(newCrcSite);
        await _context.SaveChangesAsync();
        return newCrcSite;
    }

    public async Task<PiSite> UpdateAsync(PiSite crcsite)
    {
        _context.PiSites.Update(crcsite);
        await _context.SaveChangesAsync();
        return crcsite;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crcsite = await GetByIdAsync(id);
        if (crcsite == null) return false;

        _context.PiSites.Remove(crcsite);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteByPiIdAsync(Guid id)
    {
        var crcsites = await _context.PiSites.Where(x => x.PiId == id).ToListAsync();
        if (crcsites == null) return false;

        _context.PiSites.RemoveRange(crcsites);
        await _context.SaveChangesAsync();
        return true;
    }
}