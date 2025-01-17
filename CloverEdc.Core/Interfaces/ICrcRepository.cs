using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrcRepository : IBaseRepository<Crc>
{
    Task<Crc> GetByIdAsync(Guid id);
    Task<IEnumerable<Crc>> GetAllAsync();
    Task<Crc> CreateAsync(CrcDto crc);
    Task<Crc> UpdateAsync(Crc item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<Crc>> GetCrcsByStudyIdAsync(Guid studyId);
    Task<(IEnumerable<Crc>, int)> GetCrcsByStudyIdAsync(Guid studyId,Filter filter);

}