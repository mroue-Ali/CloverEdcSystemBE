using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfPageService : ICrfPageService
{
    private readonly ICrfPageRepository _crfpageRepository;

    public CrfPageService(ICrfPageRepository crfpageRepository)
    {
        _crfpageRepository = crfpageRepository;
    }

    public async Task<CrfPage> GetCrfPageByIdAsync(Guid id)
    {
        return await _crfpageRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CrfPage>> GetAllCrfPagesAsync()
    {
        return await _crfpageRepository.GetAllAsync();
    }

    public async Task<CrfPage> CreateCrfPageAsync(CrfPageDto crfpage)
    {
        return await _crfpageRepository.CreateAsync(crfpage);
    }

    public async Task<CrfPage> UpdateCrfPageAsync(Guid id, CrfPageDto crfpage)
    {
        var existingCrfPage = await _crfpageRepository.GetByIdAsync(id);
        if (existingCrfPage == null) throw new KeyNotFoundException("CrfPage not found");
        existingCrfPage.Name = crfpage.Name;    
        existingCrfPage.CrfFileId= crfpage.CrfFileId;
        existingCrfPage.RequiredPageId = crfpage.RequiredPageId;
        return await _crfpageRepository.UpdateAsync(existingCrfPage);
    }

    public async Task<bool> DeleteCrfPageAsync(Guid id)
    {
        return await _crfpageRepository.DeleteAsync(id);
    }
}