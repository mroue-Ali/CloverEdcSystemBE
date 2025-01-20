using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class ProtocolService : IProtocolService
{
    private readonly IProtocolRepository _protocolRepository;

    public ProtocolService(IProtocolRepository protocolRepository)
    {
        _protocolRepository = protocolRepository;
    }

    public async Task<Protocol> GetProtocolByIdAsync(Guid id)
    {
        return await _protocolRepository.GetByIdAsync(id);
    }

    public async Task<(IEnumerable<Protocol>,int)> GetPagedProtocolsAsync(Filter filter)
    {
        var (roles, totalItems) = await _protocolRepository.GetPagedProtocolsAsync(filter);

        return (roles, totalItems);
    }

    public async Task<IEnumerable<Protocol>> GetAllProtocolsAsync()
    {
        return await _protocolRepository.GetAllAsync();
    }

    public async Task<Protocol> CreateProtocolAsync(ProtocolDto protocol)
    {
        return await _protocolRepository.CreateAsync(protocol);
    }

    public async Task<Protocol> UpdateProtocolAsync(Guid id, ProtocolDto protocol)
    {
        var existingProtocol = await _protocolRepository.GetByIdAsync(id);
        if (existingProtocol == null) throw new KeyNotFoundException("Protocol not found");
        var dtoProperties = typeof(ProtocolDto).GetProperties();
        var entityProperties = typeof(Protocol).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(protocol);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingProtocol, value);
            }
        }
        
        return await _protocolRepository.UpdateAsync(existingProtocol);
    }

    public async Task<bool> DeleteProtocolAsync(Guid id)
    {
        return await _protocolRepository.DeleteAsync(id);
    }
}