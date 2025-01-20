using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrfTemplateService : ICrfTemplateService
{
    private readonly ICrfTemplateRepository _crftemplateRepository;
    private readonly ICrfFileRepository _crfFileRepository;

    public CrfTemplateService(ICrfTemplateRepository crftemplateRepository, ICrfFileRepository crfFileRepository)
    {
        _crftemplateRepository = crftemplateRepository;
        _crfFileRepository = crfFileRepository;
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
        var template = await _crftemplateRepository.CreateAsync(crftemplate);
        // add files to the crftemplate
       var inclusion= await _crfFileRepository.CreateAsync(new CrfFileDto
        {
            CrfTemplateId = template.Id,
            Name = "Incusion",
            Index = 1
        });
        var exclusion= await _crfFileRepository.CreateAsync(new CrfFileDto
        {
            CrfTemplateId = template.Id,
            Name = "Exclusion", 
            Index = 2,
            RequiredFileId = inclusion.Id
        });
        var baseLine = await _crfFileRepository.CreateAsync(new CrfFileDto
        {
            CrfTemplateId = template.Id,
            Name = "BaseLine",
            Index = 3,
            RequiredFileId = exclusion.Id
        });
        var endOfStudy = await _crfFileRepository.CreateAsync(new CrfFileDto
        {
            CrfTemplateId = template.Id,
            Name = "End Of Study",
            Index = 1000,
        });
        return template;
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
    
    public async Task<CrfTemplate> GetCrfTemplateByStudyIdAsync(Guid studyId)
    {
        return await _crftemplateRepository.GetByStudyIdAsync(studyId);
    }
    
    public async Task<IEnumerable<CrfFile>> GetCrfFilesByTemplateIdAsync(Guid templateId)
    {
        return await _crfFileRepository.GetByTemplateIdAsync(templateId);
    }
}