using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient> GetPatientByIdAsync(Guid id)
    {
        return await _patientRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _patientRepository.GetAllAsync();
    }

    public async Task<Patient> CreatePatientAsync(PatientDto patient)
    {
        return await _patientRepository.CreateAsync(patient);
    }

    public async Task<Patient> UpdatePatientAsync(Guid id, PatientDto patient)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);
        if (existingPatient == null) throw new KeyNotFoundException("Patient not found");

        existingPatient.Code = patient.Code;
        existingPatient.Name = patient.Name;
        existingPatient.SiteId = patient.SiteId;
        return await _patientRepository.UpdateAsync(existingPatient);
    }

    public async Task<bool> DeletePatientAsync(Guid id)
    {
        return await _patientRepository.DeleteAsync(id);
    }
}