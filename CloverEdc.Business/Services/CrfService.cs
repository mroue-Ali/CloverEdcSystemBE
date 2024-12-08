using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfService : ICrfService
{
    private readonly ICrfRepository _crfRepository;

    public CrfService(ICrfRepository crfRepository)
    {
        _crfRepository = crfRepository;
    }

    public async Task<Crf> GetCrfByIdAsync(Guid id)
    {
        return await _crfRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Crf>> GetAllCrfsAsync()
    {
        return await _crfRepository.GetAllAsync();
    }

    public async Task<Crf> CreateCrfAsync(CrfDto crf)
    {
        return await _crfRepository.CreateAsync(crf);
    }

    public async Task<Crf> UpdateCrfAsync(Guid id, CrfDto crf)
    {
        var existingCrf = await _crfRepository.GetByIdAsync(id);
        if (existingCrf == null) throw new KeyNotFoundException("Crf not found");

        existingCrf.CrfTemplateId = crf.CrfTemplateId;
        existingCrf.PatientId = crf.PatientId;
        existingCrf.StudyId = crf.StudyId;
        return await _crfRepository.UpdateAsync(existingCrf);
    }

    public async Task<bool> DeleteCrfAsync(Guid id)
    {
        return await _crfRepository.DeleteAsync(id);
    }
}