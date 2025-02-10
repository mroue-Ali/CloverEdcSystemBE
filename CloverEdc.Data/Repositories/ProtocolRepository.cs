using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;
using CloverEdc.Data.Helpers;

namespace CloverEdc.Data.Repositories;

public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ContextHelpers _helper;

    public ProtocolRepository(ApplicationDbContext context, ContextHelpers helper) : base(context)
    {
        _context = context;
        _helper = helper;
    }

    public async Task<Protocol> GetByIdAsync(Guid id)
    {
        return await _context.Protocols.FindAsync(id);
    }

    public async Task<(IEnumerable<Protocol>, int)> GetPagedProtocolsAsync(Filter filter)
    {
        var query = _context.Protocols.Where(p => p.IsDeleted == false).AsQueryable();
        var keyword = filter.keyword;
        if (!string.IsNullOrEmpty(keyword))
        {    
            query = query.Where(r =>
                r.Name.Contains(keyword)
            );
             
        }    
        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((filter.offset) * filter.size)
            .Take(filter.size)
            .ToListAsync();

        return (items, totalItems);
    }
    public async Task<IEnumerable<Protocol>> GetAllAsync()
    {
        return await _context.Protocols.ToListAsync();
    }

    public async Task<Protocol> CreateAsync(ProtocolDto protocol)
    {
        var newProtocol = new Protocol
        {
            Name = protocol.Name??"",
            NumOfVisits = protocol.NumOfVisits??1,
            Randomization = protocol.Randomization??false,
        };
        _context.Protocols.Add(newProtocol);
        await _context.SaveChangesAsync();
        return newProtocol;
    }

    public async Task<Protocol> UpdateAsync(Protocol protocol)
    {
        _context.Protocols.Update(protocol);
        await _context.SaveChangesAsync();
        return protocol;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var protocol = await GetByIdAsync(id);
        if (protocol == null) return false;
        
        _helper.SoftDeleteEntity(protocol);
        _context.Protocols.Update(protocol);
        await _context.SaveChangesAsync();
        return true;
    }
}