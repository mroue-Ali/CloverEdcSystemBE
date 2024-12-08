using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
{
    private readonly ApplicationDbContext _context;

    public ProtocolRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Protocol> GetByIdAsync(Guid id)
    {
        return await _context.Protocols.FindAsync(id);
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

        _context.Protocols.Remove(protocol);
        await _context.SaveChangesAsync();
        return true;
    }
}