using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;
public class BaseFieldRepository : BaseRepository<BaseField>,IBaseFieldRepository
{
    private readonly ApplicationDbContext _context;

    public BaseFieldRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<BaseField> AddAsync(BaseField baseField)
    {
        await _context.BaseFields.AddAsync(baseField);
        await _context.SaveChangesAsync();
        return baseField;
    }
    public async Task<IEnumerable<BaseField>> GetByCrfTemplateIdAsync(Guid crfTemplateId)
    {
        return await _context.BaseFields
            .Where(b => b.CrfTemplateId == crfTemplateId)
            .Include(x=>x.Type)
            .Include(b => b.DropDownOptions) // Include dropdown options
            .ToListAsync();
    }
    public async Task<BaseField> GetByIdAsync(Guid id)
    {
        return await _context.BaseFields
            .Include(b => b.DropDownOptions) // Include dropdown options
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<BaseField>> GetAllAsync()
    {
        return await _context.BaseFields
            .Include(b => b.DropDownOptions) // Include dropdown options
            .ToListAsync();
    }
}
