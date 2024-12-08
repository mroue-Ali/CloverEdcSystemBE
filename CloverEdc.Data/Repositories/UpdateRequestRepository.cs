using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class UpdateRequestRepository : BaseRepository<UpdateRequest>, IUpdateRequestRepository
{
    private readonly ApplicationDbContext _context;

    public UpdateRequestRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UpdateRequest> GetByIdAsync(Guid id)
    {
        return await _context.UpdateRequests.FindAsync(id);
    }

    public async Task<IEnumerable<UpdateRequest>> GetAllAsync()
    {
        return await _context.UpdateRequests.ToListAsync();
    }

    public async Task<UpdateRequest> CreateAsync(UpdateRequestDto updaterequest)
    {
        var newUpdateRequest = new UpdateRequest
        {
            CrfValueId = updaterequest.CrfValueId,
            Status = updaterequest.Status,
            Reason = updaterequest.Reason,
            NewValue = updaterequest.NewValue,
            CrcId = updaterequest.CrcId,
        };
        _context.UpdateRequests.Add(newUpdateRequest);
        await _context.SaveChangesAsync();
        return newUpdateRequest;
    }

    public async Task<UpdateRequest> UpdateAsync(UpdateRequest updaterequest)
    {
        _context.UpdateRequests.Update(updaterequest);
        await _context.SaveChangesAsync();
        return updaterequest;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var updaterequest = await GetByIdAsync(id);
        if (updaterequest == null) return false;

        _context.UpdateRequests.Remove(updaterequest);
        await _context.SaveChangesAsync();
        return true;
    }
}