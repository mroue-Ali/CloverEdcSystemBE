using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SiteController : ControllerBase
{
    private readonly ISiteService _siteService;

    public SiteController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSiteById(Guid id)
    {
        var result = await _siteService.GetSiteByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllSites([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var sites = await _siteService.GetAllSitesAsync();
        var count = sites.Count();
        //var (sites,count) = await _siteService.GetPagedSitesAsync(validFilter);
        return Ok(new Response<IEnumerable<Site>>(200, "Sites retrieved successfully", sites,count));
    }
    
    [HttpGet("{studyId}/study")]
    public async Task<IActionResult> GetAllSitesByStudyId(Guid studyId)
    {
        try
        {
            var sites = await _siteService.GetSitesByStudyIdAsync(studyId);
            return Ok(new Response<IEnumerable<Site>>(200, "Sites retrieved successfully", sites));
            
        }
        catch (Exception e)
        {
            return NotFound(new Response<string>(500, "Internal Server Error"));

        }
     
    }
    [HttpPost("{siteId}/pi")]
    public async Task<IActionResult> AddPrincipalInvestigatorToSite(Guid siteId, [FromBody] RegisterUserDto user)
    {
        try
        {
            var createdUser = await _siteService.AddPrincipalInvestigatorToSiteAsync(siteId, user);
            return Ok(new Response<Pi>(200, "Principal Investigator added successfully", createdUser));
        }
        catch (Exception e)
        {
            return NotFound(new Response<string>(500, "Internal Server Error"));

        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateSite(SiteDto site)
    {
        var createdSite = await _siteService.CreateSiteAsync(site);
        return CreatedAtAction(nameof(GetSiteById), new { id = createdSite.Id }, createdSite);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSite(Guid id, [FromBody] SiteDto site)
    {
        try
        {
            var updatedSite = await _siteService.UpdateSiteAsync(id, site);
            return Ok(new Response<Site>(200, "Site updated successfully", updatedSite));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Site not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSite(Guid id)
    {
        var isDeleted = await _siteService.DeleteSiteAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Site not found"));
        
        return Ok(new Response<string>(200, "Site deleted successfully"));
    }

    
    
}