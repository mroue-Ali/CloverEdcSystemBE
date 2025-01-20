using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuditTrailController : ControllerBase
{
    private readonly IAuditTrailService _audittrailService;

    public AuditTrailController(IAuditTrailService audittrailService)
    {
        _audittrailService = audittrailService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuditTrailById(Guid id)
    {
        var result = await _audittrailService.GetAuditTrailByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllAuditTrails([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var audittrails = await _audittrailService.GetAllAuditTrailsAsync();
        var count = audittrails.Count();
        //var (audittrails,count) = await _audittrailService.GetPagedAuditTrailsAsync(validFilter);
        return Ok(new Response<IEnumerable<AuditTrail>>(200, "AuditTrails retrieved successfully", audittrails,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAuditTrail(AuditTrailDto audittrail)
    {
        var createdAuditTrail = await _audittrailService.CreateAuditTrailAsync(audittrail);
        return CreatedAtAction(nameof(GetAuditTrailById), new { id = createdAuditTrail.Id }, createdAuditTrail);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuditTrail(Guid id, [FromBody] AuditTrailDto audittrail)
    {
        try
        {
            var updatedAuditTrail = await _audittrailService.UpdateAuditTrailAsync(id, audittrail);
            return Ok(new Response<AuditTrail>(200, "AuditTrail updated successfully", updatedAuditTrail));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "AuditTrail not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuditTrail(Guid id)
    {
        var isDeleted = await _audittrailService.DeleteAuditTrailAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "AuditTrail not found"));
        
        return Ok(new Response<string>(200, "AuditTrail deleted successfully"));
    }

    
    
}