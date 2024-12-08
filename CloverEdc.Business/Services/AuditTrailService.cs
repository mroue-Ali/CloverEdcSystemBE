using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class AuditTrailService : IAuditTrailService
{
    private readonly IAuditTrailRepository _audittrailRepository;

    public AuditTrailService(IAuditTrailRepository audittrailRepository)
    {
        _audittrailRepository = audittrailRepository;
    }

    public async Task<AuditTrail> GetAuditTrailByIdAsync(Guid id)
    {
        return await _audittrailRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AuditTrail>> GetAllAuditTrailsAsync()
    {
        return await _audittrailRepository.GetAllAsync();
    }

    public async Task<AuditTrail> CreateAuditTrailAsync(AuditTrailDto audittrail)
    {
        return await _audittrailRepository.CreateAsync(audittrail);
    }

    public async Task<AuditTrail> UpdateAuditTrailAsync(Guid id, AuditTrailDto audittrail)
    {
        var existingAuditTrail = await _audittrailRepository.GetByIdAsync(id);
        if (existingAuditTrail == null) throw new KeyNotFoundException("AuditTrail not found");
    
        existingAuditTrail.UserId = audittrail.UserId;  
        existingAuditTrail.Action = audittrail.Action;
        existingAuditTrail.Timestamp = DateTime.Now;
        
        return await _audittrailRepository.UpdateAsync(existingAuditTrail);
    }

    public async Task<bool> DeleteAuditTrailAsync(Guid id)
    {
        return await _audittrailRepository.DeleteAsync(id);
    }
}