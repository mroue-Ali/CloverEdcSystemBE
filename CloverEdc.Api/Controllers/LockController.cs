using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LockController : ControllerBase
{
    private readonly ILockService _lockService;

    public LockController(ILockService lockService)
    {
        _lockService = lockService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLockById(Guid id)
    {
        var result = await _lockService.GetLockByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocks([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var locks = await _lockService.GetAllLocksAsync();
        var count = locks.Count();
        //var (locks,count) = await _lockService.GetPagedLocksAsync(validFilter);
        return Ok(new Response<IEnumerable<Lock>>(200, "Locks retrieved successfully", locks, count));
    }

    [HttpPost]
    public async Task<IActionResult> CreateLock(LockDto lockDto)
    {
        var createdLock = await _lockService.CreateLockAsync(lockDto);
        return CreatedAtAction(nameof(GetLockById), new { id = createdLock.Id }, createdLock);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLock(Guid id, [FromBody] LockDto lockDto)
    {
        try
        {
            var updatedLock = await _lockService.UpdateLockAsync(id, lockDto);
            return Ok(new Response<Lock>(200, "Lock updated successfully", updatedLock));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Lock not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLock(Guid id)
    {
        var isDeleted = await _lockService.DeleteLockAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Lock not found"));

        return Ok(new Response<string>(200, "Lock deleted successfully"));
    }
    
    
    
}