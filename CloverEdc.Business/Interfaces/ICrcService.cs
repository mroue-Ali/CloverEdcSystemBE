using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrcService
{
    Task<Crc> GetCrcByIdAsync(Guid id);
    Task<IEnumerable<Crc>> GetAllCrcsAsync();
    Task<Crc> CreateCrcAsync(CrcDto crc, Guid studyId);
    Task<Crc> UpdateCrcAsync(Guid id, CrcDto crc);
    Task<bool> DeleteCrcAsync(Guid id);
    Task<IEnumerable<Crc>> GetCrcsByStudyIdAsync(Guid studyId);
    Task<(IEnumerable<Crc>, int)> GetCrcsByStudyIdAsync(Guid studyId,Filter filter);

}