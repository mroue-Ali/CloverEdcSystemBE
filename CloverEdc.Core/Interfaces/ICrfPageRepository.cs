using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfPageRepository : IBaseRepository<CrfPage>
{
    Task<CrfPage> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfPage>> GetAllAsync();
    Task<CrfPage> CreateAsync(CrfPageDto crfpage);
    Task<CrfPage> UpdateAsync(CrfPage item);
    Task<bool> DeleteAsync(Guid id);
}