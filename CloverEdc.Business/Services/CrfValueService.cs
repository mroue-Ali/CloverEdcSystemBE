using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfValueService : ICrfValueService
{
    private readonly ICrfValueRepository _crfvalueRepository;

    public CrfValueService(ICrfValueRepository crfvalueRepository)
    {
        _crfvalueRepository = crfvalueRepository;
    }

    public async Task<CrfValue> GetCrfValueByIdAsync(Guid id)
    {
        return await _crfvalueRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CrfValue>> GetAllCrfValuesAsync()
    {
        return await _crfvalueRepository.GetAllAsync();
    }

    public async Task<CrfValue> CreateCrfValueAsync(CrfValueDto crfvalue)
    {
        return await _crfvalueRepository.CreateAsync(crfvalue);
    }

    public async Task<CrfValue> UpdateCrfValueAsync(Guid id, CrfValueDto crfvalue)
    {
        var existingCrfValue = await _crfvalueRepository.GetByIdAsync(id);
        if (existingCrfValue == null) throw new KeyNotFoundException("CrfValue not found");

        existingCrfValue.Value = crfvalue.Value;
        existingCrfValue.CrfFieldId = crfvalue.CrfFieldId;
        existingCrfValue.CrfId = crfvalue.CrfId;
        existingCrfValue.IsModified = true;
        existingCrfValue.DateUpdated = DateTime.Now;

        return await _crfvalueRepository.UpdateAsync(existingCrfValue);
    }

    public async Task<bool> DeleteCrfValueAsync(Guid id)
    {
        return await _crfvalueRepository.DeleteAsync(id);
    }
}