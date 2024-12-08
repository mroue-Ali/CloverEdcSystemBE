using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class SiteService : ISiteService
{
    private readonly ISiteRepository _siteRepository;
    private readonly IRoleRepository _roleRepository;

    public SiteService(ISiteRepository siteRepository,IRoleRepository roleRepository)
    {
        _siteRepository = siteRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Site> GetSiteByIdAsync(Guid id)
    {
        return await _siteRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Site>> GetAllSitesAsync()
    {
        return await _siteRepository.GetAllAsync();
    }

    public async Task<Site> CreateSiteAsync(SiteDto site)
    {
        return await _siteRepository.CreateAsync(site);
    }

    public async Task<Site> UpdateSiteAsync(Guid id, SiteDto site)
    {
        var existingSite = await _siteRepository.GetByIdAsync(id);
        if (existingSite == null) throw new KeyNotFoundException("Site not found");
        
        var dtoProperties = typeof(SiteDto).GetProperties();
        var entityProperties = typeof(Site).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(site);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingSite, value);
            }
        }
        
        return await _siteRepository.UpdateAsync(existingSite);
    }

    public async Task<bool> DeleteSiteAsync(Guid id)
    {
        return await _siteRepository.DeleteAsync(id);
    }
    
    public async Task<IEnumerable<Site>> GetSitesByStudyIdAsync(Guid studyId)
    {
        return await _siteRepository.GetSitesByStudyIdAsync(studyId);
    }
    
    public async Task<Pi> AddPrincipalInvestigatorToSiteAsync(Guid siteId, RegisterUserDto user)
    {
        var site = await _siteRepository.GetByIdAsync(siteId);
        if (site == null) return null;
        var role = await _roleRepository.GetRoleByNameAsync("PI");
        var newUser = new User
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            Email = user.Email,
            RoleId = role.Id,
            StudyId = site.StudyId
        };

        return await _siteRepository.AddPrincipalInvestigatorToSiteAsync(siteId, newUser);
    }
}