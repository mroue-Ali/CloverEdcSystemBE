using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfTemplateService
{
    Task<CrfTemplate> GetCrfTemplateByIdAsync(Guid id);
    Task<IEnumerable<CrfTemplate>> GetAllCrfTemplatesAsync();
    Task<CrfTemplate> CreateCrfTemplateAsync(CrfTemplateDto crftemplate);
    Task<CrfTemplate> UpdateCrfTemplateAsync(Guid id, CrfTemplateDto crftemplate);
    Task<bool> DeleteCrfTemplateAsync(Guid id);
    Task<CrfTemplate> GetCrfTemplateByStudyIdAsync(Guid studyId);
    Task<IEnumerable<CrfFile>> GetCrfFilesByTemplateIdAsync(Guid templateId);
}