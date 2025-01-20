using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class QueryController : ControllerBase
{
    private readonly IQueryService _queryService;

    public QueryController(IQueryService queryService)
    {
        _queryService = queryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQueryById(Guid id)
    {
        var result = await _queryService.GetQueryByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllQueries([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var queries = await _queryService.GetAllQueriesAsync();
        var count = queries.Count();
        //var (queries,count) = await _queryService.GetPagedQueriesAsync(validFilter);
        return Ok(new Response<IEnumerable<Query>>(200, "Queries retrieved successfully", queries,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateQuery(QueryDto query)
    {
        var createdQuery = await _queryService.CreateQueryAsync(query);
        return CreatedAtAction(nameof(GetQueryById), new { id = createdQuery.Id }, createdQuery);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuery(Guid id, [FromBody] QueryDto query)
    {
        try
        {
            var updatedQuery = await _queryService.UpdateQueryAsync(id, query);
            return Ok(new Response<Query>(200, "Query updated successfully", updatedQuery));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Query not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuery(Guid id)
    {
        var isDeleted = await _queryService.DeleteQueryAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Query not found"));
        
        return Ok(new Response<string>(200, "Query deleted successfully"));
    }

    
    
}