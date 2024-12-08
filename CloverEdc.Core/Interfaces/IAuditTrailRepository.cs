using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IAuditTrailRepository : IBaseRepository<AuditTrail>
{
    Task<AuditTrail> GetByIdAsync(Guid id);
    Task<IEnumerable<AuditTrail>> GetAllAsync();
    Task<AuditTrail> CreateAsync(AuditTrailDto audittrail);
    Task<AuditTrail> UpdateAsync(AuditTrail item);
    Task<bool> DeleteAsync(Guid id);
}