using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfController : ControllerBase
{
    private readonly ICrfService _crfService;

    public CrfController(ICrfService crfService)
    {
        _crfService = crfService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfById(Guid id)
    {
        var result = await _crfService.GetCrfByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfs([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crfs = await _crfService.GetAllCrfsAsync();
        var count = crfs.Count();
        //var (crfs,count) = await _crfService.GetPagedCrfsAsync(validFilter);
        return Ok(new Response<IEnumerable<Crf>>(200, "Crfs retrieved successfully", crfs,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrf(CrfDto crf)
    {
        var createdCrf = await _crfService.CreateCrfAsync(crf);
        return CreatedAtAction(nameof(GetCrfById), new { id = createdCrf.Id }, createdCrf);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrf(Guid id, [FromBody] CrfDto crf)
    {
        try
        {
            var updatedCrf = await _crfService.UpdateCrfAsync(id, crf);
            return Ok(new Response<Crf>(200, "Crf updated successfully", updatedCrf));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Crf not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrf(Guid id)
    {
        var isDeleted = await _crfService.DeleteCrfAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Crf not found"));
        
        return Ok(new Response<string>(200, "Crf deleted successfully"));
    }

    
    
}