using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface ICrfFileRepository : IBaseRepository<CrfFile>
{
    Task<CrfFile> GetByIdAsync(Guid id);
    Task<IEnumerable<CrfFile>> GetAllAsync();
    Task<CrfFile> CreateAsync(CrfFileDto crffile);
    //GetLastIndexAsync
    Task<CrfFile> GetLastIndexAsync(Guid templateId);
    Task<CrfFile> UpdateAsync(CrfFile item);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<CrfFile>> GetByTemplateIdAsync(Guid templateId);
    Task SoftDeleteFileAsync(Guid fileId);
    Task ActualDeleteFileAsync(Guid fileId);

}