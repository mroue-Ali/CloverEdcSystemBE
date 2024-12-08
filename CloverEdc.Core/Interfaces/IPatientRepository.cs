using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<Patient> GetByIdAsync(Guid id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<Patient> CreateAsync(PatientDto patient);
    Task<Patient> UpdateAsync(Patient item);
    Task<bool> DeleteAsync(Guid id);
}