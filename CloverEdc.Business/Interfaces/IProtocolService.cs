using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IProtocolService
{
    Task<Protocol> GetProtocolByIdAsync(Guid id);
    Task<IEnumerable<Protocol>> GetAllProtocolsAsync();
    Task<Protocol> CreateProtocolAsync(ProtocolDto protocol);
    Task<Protocol> UpdateProtocolAsync(Guid id, ProtocolDto protocol);
    Task<bool> DeleteProtocolAsync(Guid id);
}