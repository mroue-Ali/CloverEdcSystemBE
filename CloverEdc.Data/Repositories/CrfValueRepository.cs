using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfValueRepository : BaseRepository<CrfValue>, ICrfValueRepository
{
    private readonly ApplicationDbContext _context;

    public CrfValueRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrfValue> GetByIdAsync(Guid id)
    {
        return await _context.CrfValues.FindAsync(id);
    }

    public async Task<IEnumerable<CrfValue>> GetAllAsync()
    {
        return await _context.CrfValues.ToListAsync();
    }

    public async Task<CrfValue> CreateAsync(CrfValueDto crfvalue)
    {
        var newCrfValue = new CrfValue
        {
            CrfFieldId = crfvalue.CrfFieldId,
            FileId = crfvalue.FileId,
            DropDownValueId = crfvalue.DropDownValueId,
            Value = crfvalue.Value,
            Status = crfvalue.Status,
            IsModified = crfvalue.IsModified,
            
        };
        _context.CrfValues.Add(newCrfValue);
        await _context.SaveChangesAsync();
        return newCrfValue;
    }

    public async Task<CrfValue> UpdateAsync(CrfValue crfvalue)
    {
        _context.CrfValues.Update(crfvalue);
        await _context.SaveChangesAsync();
        return crfvalue;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crfvalue = await GetByIdAsync(id);
        if (crfvalue == null) return false;

        _context.CrfValues.Remove(crfvalue);
        await _context.SaveChangesAsync();
        return true;
    }
}