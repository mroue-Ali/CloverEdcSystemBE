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
            ParentFileId = crffile.ParentFileId,
            CrfTemplateId = crffile.CrfTemplateId,
            Index = crffile.Index
        };
        _context.CrfFiles.Add(newCrfFile);
        await _context.SaveChangesAsync();
        return newCrfFile;
    }

    public async Task<CrfFile> GetLastIndexAsync(Guid templateId)
    {
        //get the last index of the crffile but not equal to 1000
        return await _context.CrfFiles.Where(x => x.CrfTemplateId == templateId && x.Index != 1000)
            .OrderByDescending(x => x.Index).FirstOrDefaultAsync();
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

    // public async Task<IEnumerable<CrfFile>> GetByTemplateIdAsync(Guid templateId)
    // {
    //     var items = await _context.CrfFiles.Where(x => x.CrfTemplateId == templateId).Where(x=>x.ParentFileId==null).OrderBy(x=>x.Index).ToListAsync();
    //     var itemsDto = items.Select(x => new CrfFile
    //     {
    //         Id = x.Id,
    //         Name = x.Name,
    //         RequiredFileId = x.RequiredFileId,
    //         CrfTemplateId = x.CrfTemplateId,
    //         Index = x.Index,
    //         ParentFileId = x.ParentFileId,
    //         
    //         SubFiles = _context.CrfFiles.Where(a=>a.ParentFileId == x.Id).ToList()
    //         
    //     });
    //     return itemsDto;
    // }
    public async Task<IEnumerable<CrfFile>> GetByTemplateIdAsync(Guid templateId)
    {
        var rootFiles = await _context.CrfFiles
            .Where(x => x.CrfTemplateId == templateId && x.ParentFileId == null)
            .OrderBy(x => x.Index)
            .ToListAsync();

        foreach (var file in rootFiles)
        {
            file.SubFiles = await GetSubFilesAsync(file.Id);
        }

        return rootFiles;
    }

    private async Task<List<CrfFile>> GetSubFilesAsync(Guid parentId)
    {
        var subFiles = await _context.CrfFiles
            .Where(x => x.ParentFileId == parentId)
            .OrderBy(x => x.Index)
            .ToListAsync();

        foreach (var subFile in subFiles)
        {
            subFile.SubFiles = await GetSubFilesAsync(subFile.Id); // Recursively load subfiles
        }

        return subFiles;
    }

    public async Task SoftDeleteFileAsync(Guid fileId)
    {
        var file = await _context.CrfFiles.FirstOrDefaultAsync(x => x.Id == fileId);
        if (file == null) throw new Exception("File not found");

        file.IsDeleted = true;

        // Soft delete subfiles recursively
        var subFiles = await _context.CrfFiles.Where(x => x.ParentFileId == fileId).ToListAsync();
        foreach (var subFile in subFiles)
        {
            await SoftDeleteFileAsync(subFile.Id);
        }

        await _context.SaveChangesAsync();
    }

    public async Task ActualDeleteFileAsync(Guid fileId)
    {
        try
        {
            // var file = await _context.CrfFiles.FirstOrDefaultAsync(x => x.Id == fileId);
            // if (file == null) throw new Exception("File not found");
            //
            // _context.CrfFiles.Remove(file);
            // await _context.SaveChangesAsync();
            var file = await _context.CrfFiles.FirstOrDefaultAsync(x => x.Id == fileId);
            if (file == null) throw new Exception("File not found");
            
            // Delete subfiles recursively
            var subFiles = await _context.CrfFiles.Where(x => x.ParentFileId == fileId).ToListAsync();
            foreach (var subFile in subFiles)
            {
                await ActualDeleteFileAsync(subFile.Id);
            }
            
            _context.CrfFiles.Remove(file);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while deleting the file", e);
        }
      
    }
}