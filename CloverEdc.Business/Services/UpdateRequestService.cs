using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class UpdateRequestService : IUpdateRequestService
{
    private readonly IUpdateRequestRepository _updaterequestRepository;

    public UpdateRequestService(IUpdateRequestRepository updaterequestRepository)
    {
        _updaterequestRepository = updaterequestRepository;
    }

    public async Task<UpdateRequest> GetUpdateRequestByIdAsync(Guid id)
    {
        return await _updaterequestRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<UpdateRequest>> GetAllUpdateRequestsAsync()
    {
        return await _updaterequestRepository.GetAllAsync();
    }

    public async Task<UpdateRequest> CreateUpdateRequestAsync(UpdateRequestDto updaterequest)
    {
        return await _updaterequestRepository.CreateAsync(updaterequest);
    }

    public async Task<UpdateRequest> UpdateUpdateRequestAsync(Guid id, UpdateRequestDto updaterequest)
    {
        var existingUpdateRequest = await _updaterequestRepository.GetByIdAsync(id);
        if (existingUpdateRequest == null) throw new KeyNotFoundException("UpdateRequest not found");

        existingUpdateRequest.Reason = updaterequest.Reason;
        existingUpdateRequest.Status = updaterequest.Status;
        existingUpdateRequest.CrfValueId = updaterequest.CrfValueId;
        existingUpdateRequest.NewValue = updaterequest.NewValue;
        
        return await _updaterequestRepository.UpdateAsync(existingUpdateRequest);
    }

    public async Task<bool> DeleteUpdateRequestAsync(Guid id)
    {
        return await _updaterequestRepository.DeleteAsync(id);
    }
}