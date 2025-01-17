using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudyController : ControllerBase
{
    private readonly IStudyService _studyService;

    public StudyController(IStudyService studyService)
    {
        _studyService = studyService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudyById(Guid id)
    {
        var result = await _studyService.GetStudyByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllStudies([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        // var studies = await _studyService.GetAllStudiesAsync();
        // var count = studies.Count();
        var (studies,count) = await _studyService.GetPagedFilteredItemsAsync(validFilter);
        return Ok(new Response<IEnumerable<Study>>(200, "Studies retrieved successfully", studies,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStudy(StudyDto study)
    {
        var createdStudy = await _studyService.CreateStudyAsync(study);
        return CreatedAtAction(nameof(GetStudyById), new { id = createdStudy.Id }, createdStudy);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudy(Guid id, [FromBody] StudyDto study)
    {
        try
        {
            var updatedStudy = await _studyService.UpdateStudyAsync(id, study);
            return Ok(new Response<Study>(200, "Study updated successfully", updatedStudy));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Study not found"));
        }
    }
//${studyId}/admin
    [HttpPost("{studyId}/admin")]
    public async Task<IActionResult> AddAdminToStudy(Guid studyId, [FromBody] RegisterUserDto user)
    {
        try
        {
            var createdUser = await _studyService.AddAdminToStudyAsync(studyId, user);

            // send email to inform account creation and password reset
            
            return CreatedAtAction(nameof(GetStudyById), new { id = createdUser.StudyId }, createdUser);
        }
        catch (Exception e)
        {
            return NotFound(new Response<string>(500, "Internal Server Error"));

        }
     
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudy(Guid id)
    {
        var isDeleted = await _studyService.DeleteStudyAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Study not found"));
        
        return Ok(new Response<string>(200, "Study deleted successfully"));
    }

    
    
}