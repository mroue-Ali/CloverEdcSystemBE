using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IPiService
{
    Task<Pi> GetPiByIdAsync(Guid id);
    Task<IEnumerable<Pi>> GetAllPisAsync();
    Task<Pi> CreatePiAsync(PiDto pi,Guid studyId);
    Task<Pi> UpdatePiAsync(Guid id, PiDto pi);
    Task<bool> DeletePiAsync(Guid id);
    
    Task<IEnumerable<Pi>> GetPisByStudyIdAsync(Guid studyId);
    Task<(IEnumerable<Pi>, int)> GetPisByStudyIdAsync(Guid studyId,Filter filter);

}