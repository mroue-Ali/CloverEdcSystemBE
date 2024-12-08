using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ISiteRepository : IBaseRepository<Site>
{
    Task<Site> GetByIdAsync(Guid id);
    Task<IEnumerable<Site>> GetAllAsync();
    Task<Site> CreateAsync(SiteDto site);
    Task<Site> UpdateAsync(Site item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Site>> GetSitesByStudyIdAsync(Guid studyId);
    
    Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, User user);
}