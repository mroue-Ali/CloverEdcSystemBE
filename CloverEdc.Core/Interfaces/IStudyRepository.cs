using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IStudyRepository : IBaseRepository<Study>
{
    Task<Study> GetByIdAsync(Guid id);
    Task<IEnumerable<Study>> GetAllAsync();
    Task<(IEnumerable<Study>, int)> GetPagedFilteredItemsAsync(Filter filter);
    Task<Study> CreateAsync(StudyDto study);
    Task<Study> UpdateAsync(Study item);
    Task<bool> DeleteAsync(Guid id);
    Task<User> AddAdminToStudyAsync(User user);
}