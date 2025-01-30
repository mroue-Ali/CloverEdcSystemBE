using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfFieldService
{
    Task<CrfField> AddFieldToFileAsync(CrfFieldDto request);
    Task<IEnumerable<CrfField>> GetFieldsByFileIdAsync(Guid fileId);
    Task<CrfField> GetCrfFieldByIdAsync(Guid id);
    Task<IEnumerable<CrfField>> GetAllCrfFieldsAsync();
    Task<CrfField> CreateCrfFieldAsync(CrfFieldDto crffield);
    Task<CrfField> UpdateCrfFieldAsync(Guid id, CrfFieldDto crffield);
    Task<bool> DeleteCrfFieldAsync(Guid id);
}