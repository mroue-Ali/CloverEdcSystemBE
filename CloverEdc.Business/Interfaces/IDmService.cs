using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IDmService
{
    Task<Dm> GetDmByIdAsync(Guid id);
    Task<IEnumerable<Dm>> GetAllDmsAsync();
    Task<Dm> CreateDmAsync(RegisterUserDto dm,Guid studyId);
    Task<Dm> UpdateDmAsync(Guid id, DmDto dm);
    Task<bool> DeleteDmAsync(Guid id);
    Task<IEnumerable<Dm>> GetDmsByStudyIdAsync(Guid studyId);
}