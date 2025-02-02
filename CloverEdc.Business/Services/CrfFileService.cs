using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfFileService : ICrfFileService
{
    private readonly ICrfFileRepository _crffileRepository;

    public CrfFileService(ICrfFileRepository crffileRepository)
    {
        _crffileRepository = crffileRepository;
    }

    public async Task<CrfFile> GetCrfFileByIdAsync(Guid id)
    {
        return await _crffileRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CrfFile>> GetAllCrfFilesAsync()
    {
        return await _crffileRepository.GetAllAsync();
    }

    public async Task<CrfFile> CreateCrfFileAsync(CrfFileDto crffile)
    {
        var lastCrfFile = await _crffileRepository.GetLastIndexAsync(crffile.CrfTemplateId);
        if (lastCrfFile != null)
        {
            crffile.Index = lastCrfFile.Index + 1;
            crffile.RequiredFileId = lastCrfFile.Id;
        }
        else
        {
            crffile.Index = 1;
        }


        return await _crffileRepository.CreateAsync(crffile);
    }

    public async Task<CrfFile> UpdateCrfFileAsync(Guid id, CrfFileDto crffile)
    {
        var existingCrfFile = await _crffileRepository.GetByIdAsync(id);
        if (existingCrfFile == null) throw new KeyNotFoundException("CrfFile not found");

        existingCrfFile.Name = crffile.Name;
        existingCrfFile.CrfTemplateId = crffile.CrfTemplateId;
        existingCrfFile.RequiredFileId = crffile.RequiredFileId;
        return await _crffileRepository.UpdateAsync(existingCrfFile);
    }

    public async Task ActualDeleteFileAsync(Guid fileId)
    {
        try
        {
         await   _crffileRepository.ActualDeleteFileAsync(fileId);

        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while deleting the file", e);
        }
    }

    public async Task SoftDeleteFileAsync(Guid fileId)
    {
       await _crffileRepository.SoftDeleteFileAsync(fileId);
    }
    public async Task<bool> DeleteCrfFileAsync(Guid id)
    {
        return await _crffileRepository.DeleteAsync(id);
    }
}