using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfTemplateRepository : BaseRepository<CrfTemplate>, ICrfTemplateRepository
{
    private readonly ApplicationDbContext _context;

    public CrfTemplateRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrfTemplate> GetByIdAsync(Guid id)
    {
        return await _context.CrfTemplates.FindAsync(id);
    }

    public async Task<IEnumerable<CrfTemplate>> GetAllAsync()
    {
        return await _context.CrfTemplates.ToListAsync();
    }

    public async Task<CrfTemplate> CreateAsync(CrfTemplateDto crftemplate)
    {
        var newCrfTemplate = new CrfTemplate
        {
            Name = crftemplate.Name,
            Code = crftemplate.Code,
            StudyId = crftemplate.StudyId,
        };
        _context.CrfTemplates.Add(newCrfTemplate);
        await _context.SaveChangesAsync();
        return newCrfTemplate;
    }

    public async Task<CrfTemplate> UpdateAsync(CrfTemplate crftemplate)
    {
        _context.CrfTemplates.Update(crftemplate);
        await _context.SaveChangesAsync();
        return crftemplate;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crftemplate = await GetByIdAsync(id);
        if (crftemplate == null) return false;

        _context.CrfTemplates.Remove(crftemplate);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<CrfTemplate> GetByStudyIdAsync(Guid studyId)
    {
        return await _context.CrfTemplates.FirstOrDefaultAsync(x => x.StudyId == studyId);
    }
}