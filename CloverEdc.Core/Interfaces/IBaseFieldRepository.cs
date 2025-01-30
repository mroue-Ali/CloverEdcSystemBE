using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IBaseFieldRepository : IBaseRepository<BaseField>
{
    Task<IEnumerable<BaseField>> GetByCrfTemplateIdAsync(Guid crfTemplateId);
    Task<BaseField> AddAsync(BaseField baseField);
    Task<BaseField> GetByIdAsync(Guid id);
    Task<IEnumerable<BaseField>> GetAllAsync();
}
