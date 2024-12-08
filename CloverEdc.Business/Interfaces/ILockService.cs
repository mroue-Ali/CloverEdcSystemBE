using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ILockService
{
    Task<Lock> GetLockByIdAsync(Guid id);
    Task<IEnumerable<Lock>> GetAllLocksAsync();
    Task<Lock> CreateLockAsync(LockDto lockDto);
    Task<Lock> UpdateLockAsync(Guid id, LockDto lockDto);
    Task<bool> DeleteLockAsync(Guid id);
}