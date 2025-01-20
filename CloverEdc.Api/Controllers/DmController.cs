using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DmController : ControllerBase
{
    private readonly IDmService _dmService;

    public DmController(IDmService dmService)
    {
        _dmService = dmService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDmById(Guid id)
    {
        var result = await _dmService.GetDmByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllDms([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var dms = await _dmService.GetAllDmsAsync();
        var count = dms.Count();
        //var (dms,count) = await _dmService.GetPagedDmsAsync(validFilter);
        return Ok(new Response<IEnumerable<Dm>>(200, "Dms retrieved successfully", dms,count));
    }
    [HttpGet("{studyId}/study")]
    public async Task<IActionResult> GetDmsByStudyId([FromQuery] Filter filter,Guid studyId)
    {
        
        // var dms = await _dmService.GetDmsByStudyIdAsync(studyId);
        var (dms,count) = await _dmService.GetDmsByStudyIdAsync(studyId,filter);

        return Ok(new Response<IEnumerable<Dm>>(200, "Dms retrieved successfully", dms,count));
        
    }
    [HttpPost("{studyId}")]
    public async Task<IActionResult> CreateDm(RegisterUserDto dm,Guid studyId)
    {
        var createdDm = await _dmService.CreateDmAsync(dm,studyId);
        return CreatedAtAction(nameof(GetDmById), new { id = createdDm.Id }, createdDm);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDm(Guid id, [FromBody] DmDto dm)
    {
        try
        {
            var updatedDm = await _dmService.UpdateDmAsync(id, dm);
            return Ok(new Response<Dm>(200, "Dm updated successfully", updatedDm));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Dm not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDm(Guid id)
    {
        var isDeleted = await _dmService.DeleteDmAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Dm not found"));
        
        return Ok(new Response<string>(200, "Dm deleted successfully"));
    }

    
    
}