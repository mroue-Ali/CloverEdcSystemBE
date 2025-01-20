using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfRepository : BaseRepository<Crf>, ICrfRepository
{
    private readonly ApplicationDbContext _context;

    public CrfRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Crf> GetByIdAsync(Guid id)
    {
        return await _context.Crfs.FindAsync(id);
    }

    public async Task<IEnumerable<Crf>> GetAllAsync()
    {
        return await _context.Crfs.ToListAsync();
    }

    public async Task<Crf> CreateAsync(CrfDto crf)
    {
        var newCrf = new Crf
        {
            CrcId = crf.CrcId,
            PatientId = crf.PatientId,
            CrfTemplateId = crf.CrfTemplateId,
        };
        _context.Crfs.Add(newCrf);
        await _context.SaveChangesAsync();
        return newCrf;
    }

    public async Task<Crf> UpdateAsync(Crf crf)
    {
        _context.Crfs.Update(crf);
        await _context.SaveChangesAsync();
        return crf;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crf = await GetByIdAsync(id);
        if (crf == null) return false;

        _context.Crfs.Remove(crf);
        await _context.SaveChangesAsync();
        return true;
    }
}