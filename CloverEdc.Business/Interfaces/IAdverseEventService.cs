using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IAdverseEventService
{
    Task<AdverseEvent> GetAdverseEventByIdAsync(Guid id);
    Task<IEnumerable<AdverseEvent>> GetAllAdverseEventsAsync();
    Task<AdverseEvent> CreateAdverseEventAsync(AdverseEventDto adverseevent);
    Task<AdverseEvent> UpdateAdverseEventAsync(Guid id, AdverseEventDto adverseevent);
    Task<bool> DeleteAdverseEventAsync(Guid id);
}