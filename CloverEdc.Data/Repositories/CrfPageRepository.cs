using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfPageRepository : BaseRepository<CrfPage>, ICrfPageRepository
{
    private readonly ApplicationDbContext _context;

    public CrfPageRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrfPage> GetByIdAsync(Guid id)
    {
        return await _context.CrfPages.FindAsync(id);
    }

    public async Task<IEnumerable<CrfPage>> GetAllAsync()
    {
        return await _context.CrfPages.ToListAsync();
    }

    public async Task<CrfPage> CreateAsync(CrfPageDto crfpage)
    {
        var newCrfPage = new CrfPage
        {
            Name = crfpage.Name,
            CrfFileId = crfpage.CrfFileId,
            RequiredPageId = crfpage.RequiredPageId,
        };
        _context.CrfPages.Add(newCrfPage);
        await _context.SaveChangesAsync();
        return newCrfPage;
    }

    public async Task<CrfPage> UpdateAsync(CrfPage crfpage)
    {
        _context.CrfPages.Update(crfpage);
        await _context.SaveChangesAsync();
        return crfpage;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crfpage = await GetByIdAsync(id);
        if (crfpage == null) return false;

        _context.CrfPages.Remove(crfpage);
        await _context.SaveChangesAsync();
        return true;
    }
}