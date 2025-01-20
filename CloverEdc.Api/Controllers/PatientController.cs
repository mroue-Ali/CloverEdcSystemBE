using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(Guid id)
    {
        var result = await _patientService.GetPatientByIdAsync(id);
        return Ok(result);
    }
 [HttpGet]
    public async Task<IActionResult> GetAllPatients([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        var patients = await _patientService.GetAllPatientsAsync();
        var count = patients.Count();
        //var (patients,count) = await _patientService.GetPagedPatientsAsync(validFilter);
        return Ok(new Response<IEnumerable<Patient>>(200, "Patients retrieved successfully", patients,count));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePatient(PatientDto patient)
    {
        var createdPatient = await _patientService.CreatePatientAsync(patient);
        return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
    }
    
     [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientDto patient)
    {
        try
        {
            var updatedPatient = await _patientService.UpdatePatientAsync(id, patient);
            return Ok(new Response<Patient>(200, "Patient updated successfully", updatedPatient));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Patient not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(Guid id)
    {
        var isDeleted = await _patientService.DeletePatientAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Patient not found"));
        
        return Ok(new Response<string>(200, "Patient deleted successfully"));
    }

    
    
}