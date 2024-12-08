using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IQueryRepository : IBaseRepository<Query>
{
    Task<Query> GetByIdAsync(Guid id);
    Task<IEnumerable<Query>> GetAllAsync();
    Task<Query> CreateAsync(QueryDto query);
    Task<Query> UpdateAsync(Query item);
    Task<bool> DeleteAsync(Guid id);
}