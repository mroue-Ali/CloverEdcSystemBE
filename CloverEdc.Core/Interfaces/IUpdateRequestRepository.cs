using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IUpdateRequestRepository : IBaseRepository<UpdateRequest>
{
    Task<UpdateRequest> GetByIdAsync(Guid id);
    Task<IEnumerable<UpdateRequest>> GetAllAsync();
    Task<UpdateRequest> CreateAsync(UpdateRequestDto updaterequest);
    Task<UpdateRequest> UpdateAsync(UpdateRequest item);
    Task<bool> DeleteAsync(Guid id);
}