using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfValueRepository : IBaseRepository<CrfValue>
{
    Task<CrfValue> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfValue>> GetAllAsync();
    Task<CrfValue> CreateAsync(CrfValueDto crfvalue);
    Task<CrfValue> UpdateAsync(CrfValue item);
    Task<bool> DeleteAsync(Guid id);
}