using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfFieldController : ControllerBase
{
    private readonly ICrfFieldService _crffieldService;

    public CrfFieldController(ICrfFieldService crffieldService)
    {
        _crffieldService = crffieldService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfFieldById(Guid id)
    {
        var result = await _crffieldService.GetCrfFieldByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfFields([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crffields = await _crffieldService.GetAllCrfFieldsAsync();
        var count = crffields.Count();
        //var (crffields,count) = await _crffieldService.GetPagedCrfFieldsAsync(validFilter);
        return Ok(new Response<IEnumerable<CrfField>>(200, "CrfFields retrieved successfully", crffields,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrfField(CrfFieldDto crffield)
    {
        var createdCrfField = await _crffieldService.CreateCrfFieldAsync(crffield);
        return CreatedAtAction(nameof(GetCrfFieldById), new { id = createdCrfField.Id }, createdCrfField);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrfField(Guid id, [FromBody] CrfFieldDto crffield)
    {
        try
        {
            var updatedCrfField = await _crffieldService.UpdateCrfFieldAsync(id, crffield);
            return Ok(new Response<CrfField>(200, "CrfField updated successfully", updatedCrfField));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrfField not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrfField(Guid id)
    {
        var isDeleted = await _crffieldService.DeleteCrfFieldAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrfField not found"));
        
        return Ok(new Response<string>(200, "CrfField deleted successfully"));
    }

    
    
}