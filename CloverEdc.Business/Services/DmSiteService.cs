// using CloverEdc.Business.Helpers;
// using CloverEdc.Business.Interfaces;
// using CloverEdc.Core.DTOs;
// using CloverEdc.Core.Interfaces;
// using CloverEdc.Core.Models;
//
// namespace CloverEdc.Business.Services;
//
// public class DmSiteService : IDmSiteService
// {
//     private readonly IDmSiteRepository _dmsiteRepository;
//
//     public DmSiteService(IDmSiteRepository dmsiteRepository)
//     {
//         _dmsiteRepository = dmsiteRepository;
//     }
//
//     public async Task<DmSite> GetDmSiteByIdAsync(Guid id)
//     {
//         return await _dmsiteRepository.GetByIdAsync(id);
//     }
//
//     public async Task<IEnumerable<DmSite>> GetAllDmSitesAsync()
//     {
//         return await _dmsiteRepository.GetAllAsync();
//     }
//
//     public async Task<DmSite> CreateDmSiteAsync(DmSiteDto dmsite)
//     {
//         return await _dmsiteRepository.CreateAsync(dmsite);
//     }
//
//     public async Task<DmSite> UpdateDmSiteAsync(Guid id, DmSiteDto dmsite)
//     {
//         var existingDmSite = await _dmsiteRepository.GetByIdAsync(id);
//         if (existingDmSite == null) throw new KeyNotFoundException("DmSite not found");
//
//         existingDmSite.SiteId = dmsite.SiteId;  
//         existingDmSite.DmId = dmsite.DmId;
//
//         return await _dmsiteRepository.UpdateAsync(existingDmSite);
//     }
//
//     public async Task<bool> DeleteDmSiteAsync(Guid id)
//     {
//         return await _dmsiteRepository.DeleteAsync(id);
//     }
// }