using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfFieldService : ICrfFieldService
{
    private readonly ICrfFieldRepository _crffieldRepository;

    public CrfFieldService(ICrfFieldRepository crffieldRepository)
    {
        _crffieldRepository = crffieldRepository;
    }

    public async Task<CrfField> GetCrfFieldByIdAsync(Guid id)
    {
        return await _crffieldRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CrfField>> GetAllCrfFieldsAsync()
    {
        return await _crffieldRepository.GetAllAsync();
    }

    public async Task<CrfField> CreateCrfFieldAsync(CrfFieldDto crffield)
    {
        return await _crffieldRepository.CreateAsync(crffield);
    }

    public async Task<CrfField> UpdateCrfFieldAsync(Guid id, CrfFieldDto crffield)
    {
        var existingCrfField = await _crffieldRepository.GetByIdAsync(id);
        if (existingCrfField == null) throw new KeyNotFoundException("CrfField not found");
        
        existingCrfField.FieldName = crffield.FieldName;
        existingCrfField.IsRequired = crffield.IsRequired;  
        existingCrfField.BaseFieldId = crffield.BaseFieldId;
        existingCrfField.ValidationRules = crffield.ValidationRules;
        existingCrfField.RequiredFieldId = crffield.RequiredFieldId;
        return await _crffieldRepository.UpdateAsync(existingCrfField);
    }

    public async Task<bool> DeleteCrfFieldAsync(Guid id)
    {
        return await _crffieldRepository.DeleteAsync(id);
    }
}