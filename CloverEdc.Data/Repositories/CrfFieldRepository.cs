using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfFieldRepository : BaseRepository<CrfField>, ICrfFieldRepository
{
    private readonly ApplicationDbContext _context;

    public CrfFieldRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrfField> GetByIdAsync(Guid id)
    {
        return await _context.CrfFields.FindAsync(id);
    }

    public async Task<IEnumerable<CrfField>> GetAllAsync()
    {
        return await _context.CrfFields.ToListAsync();
    }

    public async Task<CrfField> CreateAsync(CrfFieldDto crffield)
    {
        var newCrfField = new CrfField
        {
            FieldName = crffield.FieldName,
            BaseFieldId = crffield.BaseFieldId,
            ValidationRules = crffield.ValidationRules,
            IsRequired = crffield.IsRequired,
            RequiredFieldId = crffield.RequiredFieldId,
            CrfFileId = crffield.CrfFileId
        };
        _context.CrfFields.Add(newCrfField);
        await _context.SaveChangesAsync();
        return newCrfField;
    }

    public async Task<CrfField> UpdateAsync(CrfField crffield)
    {
        _context.CrfFields.Update(crffield);
        await _context.SaveChangesAsync();
        return crffield;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crffield = await GetByIdAsync(id);
        if (crffield == null) return false;

        _context.CrfFields.Remove(crffield);
        await _context.SaveChangesAsync();
        return true;
    }
}