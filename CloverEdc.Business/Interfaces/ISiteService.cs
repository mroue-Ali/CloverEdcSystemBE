using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ISiteService
{
    Task<Site> GetSiteByIdAsync(Guid id);
    Task<IEnumerable<Site>> GetAllSitesAsync();
    Task<Site> CreateSiteAsync(SiteDto site);
    Task<Site> UpdateSiteAsync(Guid id, SiteDto site);
    Task<bool> DeleteSiteAsync(Guid id);
    
    Task<IEnumerable<Site>> GetSitesByStudyIdAsync(Guid studyId);
    Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, RegisterUserDto user);
}