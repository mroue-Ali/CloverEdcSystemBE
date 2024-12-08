using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfTemplateService : ICrfTemplateService
{
    private readonly ICrfTemplateRepository _crftemplateRepository;

    public CrfTemplateService(ICrfTemplateRepository crftemplateRepository)
    {
        _crftemplateRepository = crftemplateRepository;
    }

    public async Task<CrfTemplate> GetCrfTemplateByIdAsync(Guid id)
    {
        return await _crftemplateRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CrfTemplate>> GetAllCrfTemplatesAsync()
    {
        return await _crftemplateRepository.GetAllAsync();
    }

    public async Task<CrfTemplate> CreateCrfTemplateAsync(CrfTemplateDto crftemplate)
    {
        return await _crftemplateRepository.CreateAsync(crftemplate);
    }

    public async Task<CrfTemplate> UpdateCrfTemplateAsync(Guid id, CrfTemplateDto crftemplate)
    {
        var existingCrfTemplate = await _crftemplateRepository.GetByIdAsync(id);
        if (existingCrfTemplate == null) throw new KeyNotFoundException("CrfTemplate not found");

        existingCrfTemplate.Name = crftemplate.Name;
        existingCrfTemplate.Code = crftemplate.Code;
        existingCrfTemplate.StudyId = crftemplate.StudyId;
        
        return await _crftemplateRepository.UpdateAsync(existingCrfTemplate);
    }

    public async Task<bool> DeleteCrfTemplateAsync(Guid id)
    {
        return await _crftemplateRepository.DeleteAsync(id);
    }
}