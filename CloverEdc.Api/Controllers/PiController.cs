using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PiController : ControllerBase
{
    private readonly IPiService _piService;

    public PiController(IPiService piService)
    {
        _piService = piService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPiById(Guid id)
    {
        var result = await _piService.GetPiByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllPis([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var pis = await _piService.GetAllPisAsync();
        var count = pis.Count();
        //var (pis,count) = await _piService.GetPagedPisAsync(validFilter);
        return Ok(new Response<IEnumerable<Pi>>(200, "Pis retrieved successfully", pis,count));
    }
    //I want to get the pis that their site is in study of givin studyId in the parameter
    [HttpGet("{studyId}/study")]
    public async Task<IActionResult> GetPisByStudyId([FromQuery] Filter filter,Guid studyId)
    {
        
        // var pis = await _piService.GetPisByStudyIdAsync(studyId);
        var (pis,count) = await _piService.GetPisByStudyIdAsync(studyId,filter);

        return Ok(new Response<IEnumerable<Pi>>(200, "Pis retrieved successfully", pis,count));
        
    }
    
    [HttpPost("{studyId}/study")]
    public async Task<IActionResult> CreatePi(PiDto pi, Guid studyId)
    {
        var createdPi = await _piService.CreatePiAsync(pi,studyId);
        return CreatedAtAction(nameof(GetPiById), new { id = createdPi.Id }, createdPi);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePi(Guid id, [FromBody] PiDto pi)
    {
        try
        {
            var updatedPi = await _piService.UpdatePiAsync(id, pi);
            return Ok(new Response<Pi>(200, "Pi updated successfully", updatedPi));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Pi not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePi(Guid id)
    {
        var isDeleted = await _piService.DeletePiAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Pi not found"));
        
        return Ok(new Response<string>(200, "Pi deleted successfully"));
    }

    
    
}