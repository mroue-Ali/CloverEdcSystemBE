using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProtocolController : ControllerBase
{
    private readonly IProtocolService _protocolService;

    public ProtocolController(IProtocolService protocolService)
    {
        _protocolService = protocolService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProtocolById(Guid id)
    {
        var result = await _protocolService.GetProtocolByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProtocols([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var (protocols, count) = await _protocolService.GetPagedProtocolsAsync(validFilter);

        return Ok(new Response<IEnumerable<Protocol>>(200, "Protocols retrieved successfully", protocols, count));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProtocol(ProtocolDto protocol)
    {
        var createdProtocol = await _protocolService.CreateProtocolAsync(protocol);
        return CreatedAtAction(nameof(GetProtocolById), new { id = createdProtocol.Id }, createdProtocol);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProtocol(Guid id, [FromBody] ProtocolDto protocol)
    {
        try
        {
            var updatedProtocol = await _protocolService.UpdateProtocolAsync(id, protocol);
            return Ok(new Response<Protocol>(200, "Protocol updated successfully", updatedProtocol));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Protocol not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProtocol(Guid id)
    {
        var isDeleted = await _protocolService.DeleteProtocolAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Protocol not found"));

        return Ok(new Response<string>(200, "Protocol deleted successfully"));
    }
}