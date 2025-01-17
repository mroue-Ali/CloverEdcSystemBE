using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IProtocolRepository : IBaseRepository<Protocol>
{
    Task<Protocol> GetByIdAsync(Guid id);
    Task<IEnumerable<Protocol>> GetAllAsync();
    Task<(IEnumerable<Protocol>, int)> GetPagedProtocolsAsync(Filter validFilter);
    Task<Protocol> CreateAsync(ProtocolDto protocol);
    Task<Protocol> UpdateAsync(Protocol item);
    Task<bool> DeleteAsync(Guid id);
}