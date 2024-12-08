using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfValueController : ControllerBase
{
    private readonly ICrfValueService _crfvalueService;

    public CrfValueController(ICrfValueService crfvalueService)
    {
        _crfvalueService = crfvalueService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfValueById(Guid id)
    {
        var result = await _crfvalueService.GetCrfValueByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfValues([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crfvalues = await _crfvalueService.GetAllCrfValuesAsync();
        var count = crfvalues.Count();
        //var (crfvalues,count) = await _crfvalueService.GetPagedCrfValuesAsync(validFilter);
        return Ok(new Response<IEnumerable<CrfValue>>(200, "CrfValues retrieved successfully", crfvalues,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrfValue(CrfValueDto crfvalue)
    {
        var createdCrfValue = await _crfvalueService.CreateCrfValueAsync(crfvalue);
        return CreatedAtAction(nameof(GetCrfValueById), new { id = createdCrfValue.Id }, createdCrfValue);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrfValue(Guid id, [FromBody] CrfValueDto crfvalue)
    {
        try
        {
            var updatedCrfValue = await _crfvalueService.UpdateCrfValueAsync(id, crfvalue);
            return Ok(new Response<CrfValue>(200, "CrfValue updated successfully", updatedCrfValue));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrfValue not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrfValue(Guid id)
    {
        var isDeleted = await _crfvalueService.DeleteCrfValueAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrfValue not found"));
        
        return Ok(new Response<string>(200, "CrfValue deleted successfully"));
    }

    
    
}