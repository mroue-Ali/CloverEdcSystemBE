using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrcSiteService
{
    Task<CrcSite> GetCrcSiteByIdAsync(Guid id);
    Task<IEnumerable<CrcSite>> GetAllCrcSitesAsync();
    Task<CrcSite> CreateCrcSiteAsync(CrcSiteDto crcsite);
    Task<CrcSite> UpdateCrcSiteAsync(Guid id, CrcSiteDto crcsite);
    Task<bool> DeleteCrcSiteAsync(Guid id);
}