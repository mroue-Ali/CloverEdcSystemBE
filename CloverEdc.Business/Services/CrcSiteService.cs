// using CloverEdc.Business.Helpers;
// using CloverEdc.Business.Interfaces;
// using CloverEdc.Core.DTOs;
// using CloverEdc.Core.Interfaces;
// using CloverEdc.Core.Models;
//
// namespace CloverEdc.Business.Services;
//
// public class CrcSiteService : ICrcSiteService
// {
//     private readonly ICrcSiteRepository _crcsiteRepository;
//
//     public CrcSiteService(ICrcSiteRepository crcsiteRepository)
//     {
//         _crcsiteRepository = crcsiteRepository;
//     }
//
//     public async Task<CrcSite> GetCrcSiteByIdAsync(Guid id)
//     {
//         return await _crcsiteRepository.GetByIdAsync(id);
//     }
//
//     public async Task<IEnumerable<CrcSite>> GetAllCrcSitesAsync()
//     {
//         return await _crcsiteRepository.GetAllAsync();
//     }
//
//     public async Task<CrcSite> CreateCrcSiteAsync(CrcSiteDto crcsite)
//     {
//         return await _crcsiteRepository.CreateAsync(crcsite);
//     }
//
//     public async Task<CrcSite> UpdateCrcSiteAsync(Guid id, CrcSiteDto crcsite)
//     {
//         var existingCrcSite = await _crcsiteRepository.GetByIdAsync(id);
//         if (existingCrcSite == null) throw new KeyNotFoundException("CrcSite not found");
//         
//         existingCrcSite.CrcId= crcsite.CrcId;
//         existingCrcSite.SiteId= crcsite.SiteId;
//         return await _crcsiteRepository.UpdateAsync(existingCrcSite);
//     }
//
//     public async Task<bool> DeleteCrcSiteAsync(Guid id)
//     {
//         return await _crcsiteRepository.DeleteAsync(id);
//     }
// }