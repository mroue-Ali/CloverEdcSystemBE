using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class SiteRepository : BaseRepository<Site>, ISiteRepository
{
    private readonly ApplicationDbContext _context;

    public SiteRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Site> GetByIdAsync(Guid id)
    {
        return await _context.Sites.FindAsync(id);
    }

    public async Task<IEnumerable<Site>> GetAllAsync()
    {
        return await _context.Sites.Include(x => x.Study).ToListAsync();
    }

    public async Task<(IEnumerable<Site>, int)> GetPagedFilteredItemsAsync(Filter filter)
    {
        var query = _context.Sites.Include(x => x.Study).AsQueryable();
        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(r =>
                r.Name.Contains(keyword)
            );
        }

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();

        return (items, totalItems);
    }

    public async Task<Site> CreateAsync(SiteDto site)
    {
        var newSite = new Site
        {
            Name = site.Name,
            Location = site.Location,
            StudyId = site.StudyId ?? Guid.Empty,
        };
        _context.Sites.Add(newSite);
        await _context.SaveChangesAsync();
        return newSite;
    }

    public async Task<Site> UpdateAsync(Site site)
    {
        _context.Sites.Update(site);
        await _context.SaveChangesAsync();
        return site;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var site = await GetByIdAsync(id);
        if (site == null) return false;

        _context.Sites.Remove(site);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<(IEnumerable<Site>, int)> GetSitesByStudyIdAsync(Guid studyId, Filter filter)
    {
        var query = _context.Sites.Where(x => x.StudyId == studyId).Include(x => x.Study).AsQueryable();
        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(r =>
                r.Name.Contains(keyword)
            );
        }

        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();
        var sitesDto = items.Select(x => new Site
        {
            Id = x.Id,
            Name = x.Name,
            Location = x.Location,
            StudyId = x.StudyId,
            hasPi = x.PiId != null ? true : false
        });
        return (sitesDto, totalItems);
    }

    public async Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, User user)
    {
        _context.Users.Add(user);
        var pi = new Pi
        {
            UserId = user.Id,
            User = user
        };
        _context.Pis.Add(pi);
        var site = await GetByIdAsync(siteId);
        site.PiId = pi.Id;
        _context.Sites.Update(site);

        await _context.SaveChangesAsync();
        return pi;
    }
}