using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IQueryService
{
    Task<Query> GetQueryByIdAsync(Guid id);
    Task<IEnumerable<Query>> GetAllQueriesAsync();
    Task<Query> CreateQueryAsync(QueryDto query);
    Task<Query> UpdateQueryAsync(Guid id, QueryDto query);
    Task<bool> DeleteQueryAsync(Guid id);
}