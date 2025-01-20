using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class CrfFileRepository : BaseRepository<CrfFile>, ICrfFileRepository
{
    private readonly ApplicationDbContext _context;

    public CrfFileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<CrfFile> GetByIdAsync(Guid id)
    {
        return await _context.CrfFiles.FindAsync(id);
    }

    public async Task<IEnumerable<CrfFile>> GetAllAsync()
    {
        return await _context.CrfFiles.ToListAsync();
    }

    public async Task<CrfFile> CreateAsync(CrfFileDto crffile)
    {
        var newCrfFile = new CrfFile
        {
            Name = crffile.Name,
            RequiredFileId = crffile.RequiredFileId,
            CrfTemplateId = crffile.CrfTemplateId,
            Index = crffile.Index
        };
        _context.CrfFiles.Add(newCrfFile);
        await _context.SaveChangesAsync();
        return newCrfFile;
    }

    public async Task<CrfFile> UpdateAsync(CrfFile crffile)
    {
        _context.CrfFiles.Update(crffile);
        await _context.SaveChangesAsync();
        return crffile;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var crffile = await GetByIdAsync(id);
        if (crffile == null) return false;

        _context.CrfFiles.Remove(crffile);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CrfFile>> GetByTemplateIdAsync(Guid templateId)
    {
        var items = await _context.CrfFiles.Where(x => x.CrfTemplateId == templateId).ToListAsync();
        var itemsDto = items.Select(x => new CrfFile
        {
            Id = x.Id,
            Name = x.Name,
            RequiredFileId = x.RequiredFileId,
            CrfTemplateId = x.CrfTemplateId,
            Index = x.Index,
            ParentFileId = x.ParentFileId,
            SubFiles = _context.CrfFiles.Where(a=>a.ParentFileId == x.Id).ToList()
            
        });
        return itemsDto;
    }
}