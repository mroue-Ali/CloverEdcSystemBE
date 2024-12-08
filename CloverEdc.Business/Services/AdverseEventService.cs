using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class AdverseEventService : IAdverseEventService
{
    private readonly IAdverseEventRepository _adverseeventRepository;

    public AdverseEventService(IAdverseEventRepository adverseeventRepository)
    {
        _adverseeventRepository = adverseeventRepository;
    }

    public async Task<AdverseEvent> GetAdverseEventByIdAsync(Guid id)
    {
        return await _adverseeventRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AdverseEvent>> GetAllAdverseEventsAsync()
    {
        return await _adverseeventRepository.GetAllAsync();
    }

    public async Task<AdverseEvent> CreateAdverseEventAsync(AdverseEventDto adverseevent)
    {
        return await _adverseeventRepository.CreateAsync(adverseevent);
    }

    public async Task<AdverseEvent> UpdateAdverseEventAsync(Guid id, AdverseEventDto adverseevent)
    {
        var existingAdverseEvent = await _adverseeventRepository.GetByIdAsync(id);
        if (existingAdverseEvent == null) throw new KeyNotFoundException("AdverseEvent not found");
    
        existingAdverseEvent.CrfId = adverseevent.CrfId;
        existingAdverseEvent.Description = adverseevent.Description;
        existingAdverseEvent.Severity = adverseevent.Severity;
        existingAdverseEvent.IsTreated = adverseevent.IsTreated;
        existingAdverseEvent.Treatment = adverseevent.Treatment;
            
        return await _adverseeventRepository.UpdateAsync(existingAdverseEvent);
    }

    public async Task<bool> DeleteAdverseEventAsync(Guid id)
    {
        return await _adverseeventRepository.DeleteAsync(id);
    }
}