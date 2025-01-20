using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IAuditTrailService
{
    Task<AuditTrail> GetAuditTrailByIdAsync(Guid id);
    Task<IEnumerable<AuditTrail>> GetAllAuditTrailsAsync();
    Task<AuditTrail> CreateAuditTrailAsync(AuditTrailDto audittrail);
    Task<AuditTrail> UpdateAuditTrailAsync(Guid id, AuditTrailDto audittrail);
    Task<bool> DeleteAuditTrailAsync(Guid id);
}