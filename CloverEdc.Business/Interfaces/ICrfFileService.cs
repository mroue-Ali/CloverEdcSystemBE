using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface ICrfFileService
{
    Task<CrfFile> GetCrfFileByIdAsync(Guid id);
    Task<IEnumerable<CrfFile>> GetAllCrfFilesAsync();
    Task<CrfFile> CreateCrfFileAsync(CrfFileDto crffile);
    Task<CrfFile> UpdateCrfFileAsync(Guid id, CrfFileDto crffile);
    Task<bool> DeleteCrfFileAsync(Guid id);
    Task SoftDeleteFileAsync(Guid fileId);
    Task ActualDeleteFileAsync(Guid fileId);
}