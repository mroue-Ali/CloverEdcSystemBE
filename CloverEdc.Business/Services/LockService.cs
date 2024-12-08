using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class LockService : ILockService
{
    private readonly ILockRepository _lockRepository;

    public LockService(ILockRepository lockRepository)
    {
        _lockRepository = lockRepository;
    }

    public async Task<Lock> GetLockByIdAsync(Guid id)
    {
        return await _lockRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Lock>> GetAllLocksAsync()
    {
        return await _lockRepository.GetAllAsync();
    }

    public async Task<Lock> CreateLockAsync(LockDto lockDto)
    {
        return await _lockRepository.CreateAsync(lockDto);
    }

    public async Task<Lock> UpdateLockAsync(Guid id, LockDto lockDto)
    {
        var existingLock = await _lockRepository.GetByIdAsync(id);
        if (existingLock == null) throw new KeyNotFoundException("Lock not found");

        existingLock.LockedBy = lockDto.LockedBy;
        existingLock.StudyId = lockDto.StudyId;
        return await _lockRepository.UpdateAsync(existingLock);
    }

    public async Task<bool> DeleteLockAsync(Guid id)
    {
        return await _lockRepository.DeleteAsync(id);
    }
}