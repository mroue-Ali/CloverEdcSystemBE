using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UpdateRequestController : ControllerBase
{
    private readonly IUpdateRequestService _updaterequestService;

    public UpdateRequestController(IUpdateRequestService updaterequestService)
    {
        _updaterequestService = updaterequestService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUpdateRequestById(Guid id)
    {
        var result = await _updaterequestService.GetUpdateRequestByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllUpdateRequests([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var updaterequests = await _updaterequestService.GetAllUpdateRequestsAsync();
        var count = updaterequests.Count();
        //var (updaterequests,count) = await _updaterequestService.GetPagedUpdateRequestsAsync(validFilter);
        return Ok(new Response<IEnumerable<UpdateRequest>>(200, "UpdateRequests retrieved successfully", updaterequests,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUpdateRequest(UpdateRequestDto updaterequest)
    {
        var createdUpdateRequest = await _updaterequestService.CreateUpdateRequestAsync(updaterequest);
        return CreatedAtAction(nameof(GetUpdateRequestById), new { id = createdUpdateRequest.Id }, createdUpdateRequest);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUpdateRequest(Guid id, [FromBody] UpdateRequestDto updaterequest)
    {
        try
        {
            var updatedUpdateRequest = await _updaterequestService.UpdateUpdateRequestAsync(id, updaterequest);
            return Ok(new Response<UpdateRequest>(200, "UpdateRequest updated successfully", updatedUpdateRequest));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "UpdateRequest not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUpdateRequest(Guid id)
    {
        var isDeleted = await _updaterequestService.DeleteUpdateRequestAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "UpdateRequest not found"));
        
        return Ok(new Response<string>(200, "UpdateRequest deleted successfully"));
    }

    
    
}