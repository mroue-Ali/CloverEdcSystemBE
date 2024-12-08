using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IProtocolRepository : IBaseRepository<Protocol>
{
    Task<Protocol> GetByIdAsync(Guid id);
    Task<IEnumerable<Protocol>> GetAllAsync();
    Task<Protocol> CreateAsync(ProtocolDto protocol);
    Task<Protocol> UpdateAsync(Protocol item);
    Task<bool> DeleteAsync(Guid id);
}