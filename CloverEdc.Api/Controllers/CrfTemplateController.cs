using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CrfTemplateController : ControllerBase
{
    private readonly ICrfTemplateService _crftemplateService;

    public CrfTemplateController(ICrfTemplateService crftemplateService)
    {
        _crftemplateService = crftemplateService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCrfTemplateById(Guid id)
    {
        var result = await _crftemplateService.GetCrfTemplateByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllCrfTemplates([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var crftemplates = await _crftemplateService.GetAllCrfTemplatesAsync();
        var count = crftemplates.Count();
        //var (crftemplates,count) = await _crftemplateService.GetPagedCrfTemplatesAsync(validFilter);
        return Ok(new Response<IEnumerable<CrfTemplate>>(200, "CrfTemplates retrieved successfully", crftemplates,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCrfTemplate(CrfTemplateDto crftemplate)
    {
        var createdCrfTemplate = await _crftemplateService.CreateCrfTemplateAsync(crftemplate);
        return CreatedAtAction(nameof(GetCrfTemplateById), new { id = createdCrfTemplate.Id }, createdCrfTemplate);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCrfTemplate(Guid id, [FromBody] CrfTemplateDto crftemplate)
    {
        try
        {
            var updatedCrfTemplate = await _crftemplateService.UpdateCrfTemplateAsync(id, crftemplate);
            return Ok(new Response<CrfTemplate>(200, "CrfTemplate updated successfully", updatedCrfTemplate));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "CrfTemplate not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCrfTemplate(Guid id)
    {
        var isDeleted = await _crftemplateService.DeleteCrfTemplateAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "CrfTemplate not found"));
        
        return Ok(new Response<string>(200, "CrfTemplate deleted successfully"));
    }

    
    
}