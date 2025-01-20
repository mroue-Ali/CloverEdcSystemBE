using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ILockRepository : IBaseRepository<Lock>
{
    Task<Lock> GetByIdAsync(Guid id);
    Task<IEnumerable<Lock>> GetAllAsync();
    Task<Lock> CreateAsync(LockDto lockDto);
    Task<Lock> UpdateAsync(Lock item);
    Task<bool> DeleteAsync(Guid id);
}