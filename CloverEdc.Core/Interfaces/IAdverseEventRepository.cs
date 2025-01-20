using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IAdverseEventRepository : IBaseRepository<AdverseEvent>
{
    Task<AdverseEvent> GetByIdAsync(Guid id);
    Task<IEnumerable<AdverseEvent>> GetAllAsync();
    Task<AdverseEvent> CreateAsync(AdverseEventDto adverseevent);
    Task<AdverseEvent> UpdateAsync(AdverseEvent item);
    Task<bool> DeleteAsync(Guid id);
}