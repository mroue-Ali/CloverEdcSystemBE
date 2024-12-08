using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfPageService
{
    Task<CrfPage> GetCrfPageByIdAsync(Guid id);
    Task<IEnumerable<CrfPage>> GetAllCrfPagesAsync();
    Task<CrfPage> CreateCrfPageAsync(CrfPageDto crfpage);
    Task<CrfPage> UpdateCrfPageAsync(Guid id, CrfPageDto crfpage);
    Task<bool> DeleteCrfPageAsync(Guid id);
}