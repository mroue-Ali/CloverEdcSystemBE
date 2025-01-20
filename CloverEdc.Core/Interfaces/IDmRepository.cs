using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IDmRepository : IBaseRepository<Dm>
{
    Task<Dm> GetByIdAsync(Guid id);
    Task<IEnumerable<Dm>> GetAllAsync();
    Task<Dm> CreateAsync(DmDto dm);
    Task<Dm> UpdateAsync(Dm item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Dm>> GetDmsByStudyIdAsync(Guid studyId);
    Task<(IEnumerable<Dm>, int)> GetDmsByStudyIdAsync(Guid studyId,Filter filter);

}