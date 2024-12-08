using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfFileController : ControllerBase
{
    private readonly ICrfFileService _crffileService;

    public CrfFileController(ICrfFileService crffileService)
    {
        _crffileService = crffileService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfFileById(Guid id)
    {
        var result = await _crffileService.GetCrfFileByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfFiles([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crffiles = await _crffileService.GetAllCrfFilesAsync();
        var count = crffiles.Count();
        //var (crffiles,count) = await _crffileService.GetPagedCrfFilesAsync(validFilter);
        return Ok(new Response<IEnumerable<CrfFile>>(200, "CrfFiles retrieved successfully", crffiles,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrfFile(CrfFileDto crffile)
    {
        var createdCrfFile = await _crffileService.CreateCrfFileAsync(crffile);
        return CreatedAtAction(nameof(GetCrfFileById), new { id = createdCrfFile.Id }, createdCrfFile);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrfFile(Guid id, [FromBody] CrfFileDto crffile)
    {
        try
        {
            var updatedCrfFile = await _crffileService.UpdateCrfFileAsync(id, crffile);
            return Ok(new Response<CrfFile>(200, "CrfFile updated successfully", updatedCrfFile));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrfFile not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrfFile(Guid id)
    {
        var isDeleted = await _crffileService.DeleteCrfFileAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrfFile not found"));
        
        return Ok(new Response<string>(200, "CrfFile deleted successfully"));
    }

    
    
}