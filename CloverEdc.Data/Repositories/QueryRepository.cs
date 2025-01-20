using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class QueryRepository : BaseRepository<Query>, IQueryRepository
{
    private readonly ApplicationDbContext _context;

    public QueryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Query> GetByIdAsync(Guid id)
    {
        return await _context.Queries.FindAsync(id);
    }

    public async Task<IEnumerable<Query>> GetAllAsync()
    {
        return await _context.Queries.ToListAsync();
    }

    public async Task<Query> CreateAsync(QueryDto query)
    {
        var newQuery = new Query
        {
            CrfValueId = query.CrfValueId,
            DmId = query.DmId,
            QueryText = query.QueryText,
            Status = query.Status
        };
        _context.Queries.Add(newQuery);
        await _context.SaveChangesAsync();
        return newQuery;
    }

    public async Task<Query> UpdateAsync(Query query)
    {
        _context.Queries.Update(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var query = await GetByIdAsync(id);
        if (query == null) return false;

        _context.Queries.Remove(query);
        await _context.SaveChangesAsync();
        return true;
    }
}