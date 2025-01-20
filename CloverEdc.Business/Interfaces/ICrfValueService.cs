using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfValueService
{
    Task<CrfValue> GetCrfValueByIdAsync(Guid id);
    Task<IEnumerable<CrfValue>> GetAllCrfValuesAsync();
    Task<CrfValue> CreateCrfValueAsync(CrfValueDto crfvalue);
    Task<CrfValue> UpdateCrfValueAsync(Guid id, CrfValueDto crfvalue);
    Task<bool> DeleteCrfValueAsync(Guid id);
}