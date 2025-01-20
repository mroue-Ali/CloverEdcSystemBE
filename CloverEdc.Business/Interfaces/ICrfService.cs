using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfService
{
    Task<Crf> GetCrfByIdAsync(Guid id);
    Task<IEnumerable<Crf>> GetAllCrfsAsync();
    Task<Crf> CreateCrfAsync(CrfDto crf);
    Task<Crf> UpdateCrfAsync(Guid id, CrfDto crf);
    Task<bool> DeleteCrfAsync(Guid id);
}