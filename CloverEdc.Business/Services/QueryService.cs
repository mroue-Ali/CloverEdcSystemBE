using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class QueryService : IQueryService
{
    private readonly IQueryRepository _queryRepository;

    public QueryService(IQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<Query> GetQueryByIdAsync(Guid id)
    {
        return await _queryRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Query>> GetAllQueriesAsync()
    {
        return await _queryRepository.GetAllAsync();
    }

    public async Task<Query> CreateQueryAsync(QueryDto query)
    {
        return await _queryRepository.CreateAsync(query);
    }

    public async Task<Query> UpdateQueryAsync(Guid id, QueryDto query)
    {
        var existingQuery = await _queryRepository.GetByIdAsync(id);
        if (existingQuery == null) throw new KeyNotFoundException("Query not found");

        existingQuery.QueryText = query.QueryText;
        existingQuery.CrfValueId = query.CrfValueId;
        existingQuery.DmId = query.DmId;
        existingQuery.Status = query.Status;

        return await _queryRepository.UpdateAsync(existingQuery);
    }

    public async Task<bool> DeleteQueryAsync(Guid id)
    {
        return await _queryRepository.DeleteAsync(id);
    }
}