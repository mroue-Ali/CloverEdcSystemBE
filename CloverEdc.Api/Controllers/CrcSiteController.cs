using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrcSiteController : ControllerBase
{
    private readonly ICrcSiteService _crcsiteService;

    public CrcSiteController(ICrcSiteService crcsiteService)
    {
        _crcsiteService = crcsiteService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrcSiteById(Guid id)
    {
        var result = await _crcsiteService.GetCrcSiteByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrcSites([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crcsites = await _crcsiteService.GetAllCrcSitesAsync();
        var count = crcsites.Count();
        //var (crcsites,count) = await _crcsiteService.GetPagedCrcSitesAsync(validFilter);
        return Ok(new Response<IEnumerable<CrcSite>>(200, "CrcSites retrieved successfully", crcsites,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrcSite(CrcSiteDto crcsite)
    {
        var createdCrcSite = await _crcsiteService.CreateCrcSiteAsync(crcsite);
        return CreatedAtAction(nameof(GetCrcSiteById), new { id = createdCrcSite.Id }, createdCrcSite);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrcSite(Guid id, [FromBody] CrcSiteDto crcsite)
    {
        try
        {
            var updatedCrcSite = await _crcsiteService.UpdateCrcSiteAsync(id, crcsite);
            return Ok(new Response<CrcSite>(200, "CrcSite updated successfully", updatedCrcSite));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrcSite not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrcSite(Guid id)
    {
        var isDeleted = await _crcsiteService.DeleteCrcSiteAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrcSite not found"));
        
        return Ok(new Response<string>(200, "CrcSite deleted successfully"));
    }

    
    
}