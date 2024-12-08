using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IPiRepository : IBaseRepository<Pi>
{
    Task<Pi> GetByIdAsync(Guid id);
    Task<IEnumerable<Pi>> GetAllAsync();
    Task<Pi> CreateAsync(PiDto pi);
    Task<Pi> UpdateAsync(Pi item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Pi>> GetPisByStudyIdAsync(Guid studyId);
}