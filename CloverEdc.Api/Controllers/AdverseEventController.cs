using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdverseEventController : ControllerBase
{
    private readonly IAdverseEventService _adverseeventService;
    public AdverseEventController(IAdverseEventService adverseeventService)
    {
        _adverseeventService = adverseeventService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdverseEventById(Guid id)
    {
        var result = await _adverseeventService.GetAdverseEventByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllAdverseEvents([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var adverseevents = await _adverseeventService.GetAllAdverseEventsAsync();
        var count = adverseevents.Count();
        //var (adverseevents,count) = await _adverseeventService.GetPagedAdverseEventsAsync(validFilter);
        return Ok(new Response<IEnumerable<AdverseEvent>>(200, "AdverseEvents retrieved successfully", adverseevents,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdverseEvent(AdverseEventDto adverseevent)
    {
        var createdAdverseEvent = await _adverseeventService.CreateAdverseEventAsync(adverseevent);
        return CreatedAtAction(nameof(GetAdverseEventById), new { id = createdAdverseEvent.Id }, createdAdverseEvent);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdverseEvent(Guid id, [FromBody] AdverseEventDto adverseevent)
    {
        try
        {
            var updatedAdverseEvent = await _adverseeventService.UpdateAdverseEventAsync(id, adverseevent);
            return Ok(new Response<AdverseEvent>(200, "AdverseEvent updated successfully", updatedAdverseEvent));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "AdverseEvent not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdverseEvent(Guid id)
    {
        var isDeleted = await _adverseeventService.DeleteAdverseEventAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "AdverseEvent not found"));
        
        return Ok(new Response<string>(200, "AdverseEvent deleted successfully"));
    }

    
    
}