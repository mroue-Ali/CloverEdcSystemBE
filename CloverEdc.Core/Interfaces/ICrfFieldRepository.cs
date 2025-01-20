using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfFieldRepository : IBaseRepository<CrfField>
{
    Task<CrfField> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfField>> GetAllAsync();
    Task<CrfField> CreateAsync(CrfFieldDto crffield);
    Task<CrfField> UpdateAsync(CrfField item);
    Task<bool> DeleteAsync(Guid id);
}