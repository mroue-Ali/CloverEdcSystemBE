using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class DmSiteRepository : BaseRepository<DmSite>, IDmSiteRepository
{
    private readonly ApplicationDbContext _context;

    public DmSiteRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<DmSite> GetByIdAsync(Guid id)
    {
        return await _context.DmSites.FindAsync(id);
    }

    public async Task<IEnumerable<DmSite>> GetAllAsync()
    {
        return await _context.DmSites.ToListAsync();
    }

    public async Task<DmSite> CreateAsync(DmSiteDto dmsite)
    {
        var newDmSite = new DmSite
        {
            DmId = dmsite.DmId,
            SiteId = dmsite.SiteId
        };
        _context.DmSites.Add(newDmSite);
        await _context.SaveChangesAsync();
        return newDmSite;
    }

    public async Task<DmSite> UpdateAsync(DmSite dmsite)
    {
        _context.DmSites.Update(dmsite);
        await _context.SaveChangesAsync();
        return dmsite;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var dmsite = await GetByIdAsync(id);
        if (dmsite == null) return false;

        _context.DmSites.Remove(dmsite);
        await _context.SaveChangesAsync();
        return true;
    }
}