using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class LockRepository : BaseRepository<Lock>, ILockRepository
{
    private readonly ApplicationDbContext _context;

    public LockRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Lock> GetByIdAsync(Guid id)
    {
        return await _context.Locks.FindAsync(id);
    }

    public async Task<IEnumerable<Lock>> GetAllAsync()
    {
        return await _context.Locks.ToListAsync();
    }

    public async Task<Lock> CreateAsync(LockDto lockDto)
    {
        var newLock = new Lock
        {
            StudyId = lockDto.StudyId,
            LockedBy = lockDto.LockedBy
        };
        
        _context.Locks.Add(newLock);
        await _context.SaveChangesAsync();
        return newLock;
    }

    public async Task<Lock> UpdateAsync(Lock lockDto)
    {
        _context.Locks.Update(lockDto);
        await _context.SaveChangesAsync();
        return lockDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var lockDto = await GetByIdAsync(id);
        if (lockDto == null) return false;

        _context.Locks.Remove(lockDto);
        await _context.SaveChangesAsync();
        return true;
    }
}