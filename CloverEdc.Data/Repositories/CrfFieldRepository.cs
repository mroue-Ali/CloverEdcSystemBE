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
    public async Task<CrfField> AddAsync(CrfField crfField)
    {
        await _context.CrfFields.AddAsync(crfField);
        await _context.SaveChangesAsync();
        return crfField;
    }

    public async Task<IEnumerable<CrfField>> GetFieldsByFileIdAsync(Guid fileId)
    {
        // i want also to include the dropdown options and type from the base field
        return await _context.CrfFields
            .Include(f => f.BaseField).ThenInclude(x=>x.Type) // Include base field details
            .Include(f => f.BaseField).ThenInclude(x=>x.DropDownOptions) // Include dropdown options
            .Where(f => f.CrfFileId == fileId)
            .ToListAsync();
        
        // return await _context.CrfFields
            // .Include(f => f.BaseField).ThenInclude(x=>x.Type) // Include base field details
            // .Where(f => f.CrfFileId == fileId)
            // .ToListAsync();
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
            CrfFileId = crffield.CrfFileId?? Guid.Empty
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