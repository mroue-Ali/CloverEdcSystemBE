using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrcSiteRepository : IBaseRepository<CrcSite>
{
    Task<CrcSite> GetByIdAsync(Guid id);
    Task<IEnumerable<CrcSite>> GetAllAsync();
    Task<CrcSite> CreateAsync(CrcSiteDto crcsite);
    Task<CrcSite> UpdateAsync(CrcSite item);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteByCrcIdAsync(Guid id);
    
}