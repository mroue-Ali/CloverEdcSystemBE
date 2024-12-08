using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfTemplateRepository : IBaseRepository<CrfTemplate>
{
    Task<CrfTemplate> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfTemplate>> GetAllAsync();
    Task<CrfTemplate> CreateAsync(CrfTemplateDto crftemplate);
    Task<CrfTemplate> UpdateAsync(CrfTemplate item);
    Task<bool> DeleteAsync(Guid id);
}