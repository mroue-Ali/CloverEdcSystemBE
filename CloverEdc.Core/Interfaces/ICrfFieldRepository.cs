using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfFieldRepository : IBaseRepository<CrfField>
{
    Task<CrfField> AddAsync(CrfField crfField);
    Task<IEnumerable<CrfField>> GetFieldsByFileIdAsync(Guid fileId);
    Task<CrfField> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfField>> GetAllAsync();
    Task<CrfField> CreateAsync(CrfFieldDto crffield);
    Task<CrfField> UpdateAsync(CrfField item);
    Task<bool> DeleteAsync(Guid id);
}