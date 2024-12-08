using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrcSiteRepository : BaseRepository<CrcSite>, ICrcSiteRepository
{
    private readonly ApplicationDbContext _context;

    public CrcSiteRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrcSite> GetByIdAsync(Guid id)
    {
        return await _context.CrcSites.FindAsync(id);
    }

    public async Task<IEnumerable<CrcSite>> GetAllAsync()
    {
        return await _context.CrcSites.ToListAsync();
    }

    public async Task<CrcSite> CreateAsync(CrcSiteDto crcsite)
    {
        var newCrcSite = new CrcSite
        {
            CrcId = crcsite.CrcId,
            SiteId = crcsite.SiteId
        };
        _context.CrcSites.Add(newCrcSite);
        await _context.SaveChangesAsync();
        return newCrcSite;
    }

    public async Task<CrcSite> UpdateAsync(CrcSite crcsite)
    {
        _context.CrcSites.Update(crcsite);
        await _context.SaveChangesAsync();
        return crcsite;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crcsite = await GetByIdAsync(id);
        if (crcsite == null) return false;

        _context.CrcSites.Remove(crcsite);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteByCrcIdAsync(Guid id)
    {
        var crcsites = await _context.CrcSites.Where(x => x.CrcId == id).ToListAsync();
        if (crcsites == null) return false;

        _context.CrcSites.RemoveRange(crcsites);
        await _context.SaveChangesAsync();
        return true;
    }
}