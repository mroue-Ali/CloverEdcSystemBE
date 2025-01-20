using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IUpdateRequestService
{
    Task<UpdateRequest> GetUpdateRequestByIdAsync(Guid id);
    Task<IEnumerable<UpdateRequest>> GetAllUpdateRequestsAsync();
    Task<UpdateRequest> CreateUpdateRequestAsync(UpdateRequestDto updaterequest);
    Task<UpdateRequest> UpdateUpdateRequestAsync(Guid id, UpdateRequestDto updaterequest);
    Task<bool> DeleteUpdateRequestAsync(Guid id);
}