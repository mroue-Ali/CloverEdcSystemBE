using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IDmSiteRepository : IBaseRepository<DmSite>
{
    Task<DmSite> GetByIdAsync(Guid id);
    Task<IEnumerable<DmSite>> GetAllAsync();
    Task<DmSite> CreateAsync(DmSiteDto dmsite);
    Task<DmSite> UpdateAsync(DmSite item);
    Task<bool> DeleteAsync(Guid id);
}