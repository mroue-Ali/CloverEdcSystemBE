using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IPatientService
{
    Task<Patient> GetPatientByIdAsync(Guid id);
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task<Patient> CreatePatientAsync(PatientDto patient);
    Task<Patient> UpdatePatientAsync(Guid id, PatientDto patient);
    Task<bool> DeletePatientAsync(Guid id);
}