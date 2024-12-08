using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfRepository : IBaseRepository<Crf>
{
    Task<Crf> GetByIdAsync(Guid id);
    Task<IEnumerable<Crf>> GetAllAsync();
    Task<Crf> CreateAsync(CrfDto crf);
    Task<Crf> UpdateAsync(Crf item);
    Task<bool> DeleteAsync(Guid id);
}