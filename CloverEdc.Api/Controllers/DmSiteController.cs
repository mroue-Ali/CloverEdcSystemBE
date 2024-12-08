using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DmSiteController : ControllerBase
{
    private readonly IDmSiteService _dmsiteService;

    public DmSiteController(IDmSiteService dmsiteService)
    {
        _dmsiteService = dmsiteService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDmSiteById(Guid id)
    {
        var result = await _dmsiteService.GetDmSiteByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllDmSites([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var dmsites = await _dmsiteService.GetAllDmSitesAsync();
        var count = dmsites.Count();
        //var (dmsites,count) = await _dmsiteService.GetPagedDmSitesAsync(validFilter);
        return Ok(new Response<IEnumerable<DmSite>>(200, "DmSites retrieved successfully", dmsites,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDmSite(DmSiteDto dmsite)
    {
        var createdDmSite = await _dmsiteService.CreateDmSiteAsync(dmsite);
        return CreatedAtAction(nameof(GetDmSiteById), new { id = createdDmSite.Id }, createdDmSite);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDmSite(Guid id, [FromBody] DmSiteDto dmsite)
    {
        try
        {
            var updatedDmSite = await _dmsiteService.UpdateDmSiteAsync(id, dmsite);
            return Ok(new Response<DmSite>(200, "DmSite updated successfully", updatedDmSite));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "DmSite not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDmSite(Guid id)
    {
        var isDeleted = await _dmsiteService.DeleteDmSiteAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "DmSite not found"));
        
        return Ok(new Response<string>(200, "DmSite deleted successfully"));
    }

    
    
}