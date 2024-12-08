using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IStudyService
{
    Task<Study> GetStudyByIdAsync(Guid id);
    Task<IEnumerable<Study>> GetAllStudiesAsync();
    Task<Study> CreateStudyAsync(StudyDto study);
    Task<Study> UpdateStudyAsync(Guid id, StudyDto study);
    Task<bool> DeleteStudyAsync(Guid id);
    Task<User> AddAdminToStudyAsync(Guid studyId, RegisterUserDto user);
}