using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ISiteService
{
    Task<Site> GetSiteByIdAsync(Guid id);
    Task<IEnumerable<Site>> GetAllSitesAsync();
    Task<(IEnumerable<Site>, int)> GetPagedFilteredItemsAsync(Filter filter);

    Task<Site> CreateSiteAsync(SiteDto site);
    Task<Site> UpdateSiteAsync(Guid id, SiteDto site);
    Task<bool> DeleteSiteAsync(Guid id);
    
    Task<(IEnumerable<Site>, int)> GetSitesByStudyIdAsync(Guid studyId,Filter filter);
    Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, RegisterUserDto user);
}