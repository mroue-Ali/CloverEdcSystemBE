using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfFileRepository : IBaseRepository<CrfFile>
{
    Task<CrfFile> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfFile>> GetAllAsync();
    Task<CrfFile> CreateAsync(CrfFileDto crffile);
    Task<CrfFile> UpdateAsync(CrfFile item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<CrfFile>> GetByTemplateIdAsync(Guid templateId);
    
}