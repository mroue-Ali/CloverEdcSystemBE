using System.Runtime.InteropServices.JavaScript;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseFieldController : ControllerBase
{
    private readonly IBaseFieldService _baseFieldService;

    public BaseFieldController(IBaseFieldService baseFieldService)
    {
        _baseFieldService = baseFieldService;
    }

    [HttpGet("crftemplate/{crfTemplateId}")]
    public async Task<IActionResult> GetBaseFieldsByCrfTemplateId(Guid crfTemplateId)
    {
        var baseFields = await _baseFieldService.GetBaseFieldsByCrfTemplateIdAsync(crfTemplateId);
        return Ok(baseFields);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBaseField([FromBody] BaseFieldDto request)
    {
        var baseField = await _baseFieldService.CreateBaseFieldAsync(
            request.Name,
            request.TypeId?? Guid.Empty,
            request.CrfTemplateId?? Guid.Empty,
            request.Options
        );
        return Ok(baseField);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBaseFieldById(Guid id)
    {
        var baseField = await _baseFieldService.GetBaseFieldByIdAsync(id);
        if (baseField == null) return NotFound();
        return Ok(baseField);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBaseFields()
    {
        var baseFields = await _baseFieldService.GetAllBaseFieldsAsync();
        return Ok(baseFields);
    }
}
