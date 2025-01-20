using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ISiteRepository : IBaseRepository<Site>
{
    Task<Site> GetByIdAsync(Guid id);
    Task<IEnumerable<Site>> GetAllAsync();
    Task<Site> CreateAsync(SiteDto site); 
    Task<(IEnumerable<Site>, int)> GetPagedFilteredItemsAsync(Filter filter);
    Task<Site> UpdateAsync(Site item);
    Task<bool> DeleteAsync(Guid id);
    Task<(IEnumerable<Site>, int)> GetSitesByStudyIdAsync(Guid studyId,Filter filter);
    
    Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, User user);
}