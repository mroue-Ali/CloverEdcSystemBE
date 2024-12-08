using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfPageController : ControllerBase
{
    private readonly ICrfPageService _crfpageService;

    public CrfPageController(ICrfPageService crfpageService)
    {
        _crfpageService = crfpageService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfPageById(Guid id)
    {
        var result = await _crfpageService.GetCrfPageByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfPages([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crfpages = await _crfpageService.GetAllCrfPagesAsync();
        var count = crfpages.Count();
        //var (crfpages,count) = await _crfpageService.GetPagedCrfPagesAsync(validFilter);
        return Ok(new Response<IEnumerable<CrfPage>>(200, "CrfPages retrieved successfully", crfpages,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrfPage(CrfPageDto crfpage)
    {
        var createdCrfPage = await _crfpageService.CreateCrfPageAsync(crfpage);
        return CreatedAtAction(nameof(GetCrfPageById), new { id = createdCrfPage.Id }, createdCrfPage);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrfPage(Guid id, [FromBody] CrfPageDto crfpage)
    {
        try
        {
            var updatedCrfPage = await _crfpageService.UpdateCrfPageAsync(id, crfpage);
            return Ok(new Response<CrfPage>(200, "CrfPage updated successfully", updatedCrfPage));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrfPage not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrfPage(Guid id)
    {
        var isDeleted = await _crfpageService.DeleteCrfPageAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrfPage not found"));
        
        return Ok(new Response<string>(200, "CrfPage deleted successfully"));
    }

    
    
}