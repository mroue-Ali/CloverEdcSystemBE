using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrcController : ControllerBase
{
    private readonly ICrcService _crcService;

    public CrcController(ICrcService crcService)
    {
        _crcService = crcService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrcById(Guid id)
    {
        var result = await _crcService.GetCrcByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrcs([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
            var crcs = await _crcService.GetAllCrcsAsync();
        var count = crcs.Count();
        //var (crcs,count) = await _crcService.GetPagedCrcsAsync(validFilter);
        return Ok(new Response<IEnumerable<Crc>>(200, "Crcs retrieved successfully", crcs,count));
    }
    [HttpGet("{studyId}/study")]
    public async Task<IActionResult> GetCrcsByStudyId(Guid studyId)
    {
        var crcs = await _crcService.GetCrcsByStudyIdAsync(studyId);
        return Ok(new Response<IEnumerable<Crc>>(200, "Crcs retrieved successfully", crcs));
    }
    
    [HttpPost("{studyId}/study")]
    public async Task<IActionResult> CreateCrc(CrcDto crc, Guid studyId)
    {
        var createdCrc = await _crcService.CreateCrcAsync(crc,studyId);
        return CreatedAtAction(nameof(GetCrcById), new { id = createdCrc.Id }, createdCrc);
    }
   
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrc(Guid id, [FromBody] CrcDto crc)
    {
        try
        {
            var updatedCrc = await _crcService.UpdateCrcAsync(id, crc);
            return Ok(new Response<Crc>(200, "Crc updated successfully", updatedCrc));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Crc not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrc(Guid id)
    {
        
        var isDeleted = await _crcService.DeleteCrcAsync(id);
        
        if (!isDeleted) return NotFound(new Response<string>(404, "Crc not found"));
        
        return Ok(new Response<string>(200, "Crc deleted successfully"));
    }

    
    
}