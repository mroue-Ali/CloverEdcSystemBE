using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class AdverseEventRepository : BaseRepository<AdverseEvent>, IAdverseEventRepository
{
    private readonly ApplicationDbContext _context;

    public AdverseEventRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AdverseEvent> GetByIdAsync(Guid id)
    {
        return await _context.AdverseEvents.FindAsync(id);
    }

    public async Task<IEnumerable<AdverseEvent>> GetAllAsync()
    {
        return await _context.AdverseEvents.ToListAsync();
    }

    public async Task<AdverseEvent> CreateAsync(AdverseEventDto adverseevent)
    {
        var newAdverseEvent = new AdverseEvent
        {
            CrfId = adverseevent.CrfId,
            Description = adverseevent.Description,
            Severity = adverseevent.Severity,
            IsTreated = adverseevent.IsTreated,
            Treatment = adverseevent.Treatment
        };
        
        _context.AdverseEvents.Add(newAdverseEvent);
        await _context.SaveChangesAsync();
        return newAdverseEvent;
    }

    public async Task<AdverseEvent> UpdateAsync(AdverseEvent adverseevent)
    {
        _context.AdverseEvents.Update(adverseevent);
        await _context.SaveChangesAsync();
        return adverseevent;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var adverseevent = await GetByIdAsync(id);
        if (adverseevent == null) return false;

        _context.AdverseEvents.Remove(adverseevent);
        await _context.SaveChangesAsync();
        return true;
    }
}