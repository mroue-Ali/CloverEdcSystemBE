using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IDmSiteService
{
    Task<DmSite> GetDmSiteByIdAsync(Guid id);
    Task<IEnumerable<DmSite>> GetAllDmSitesAsync();
    Task<DmSite> CreateDmSiteAsync(DmSiteDto dmsite);
    Task<DmSite> UpdateDmSiteAsync(Guid id, DmSiteDto dmsite);
    Task<bool> DeleteDmSiteAsync(Guid id);
}