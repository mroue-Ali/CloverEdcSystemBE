using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class AuditTrailRepository : BaseRepository<AuditTrail>, IAuditTrailRepository
{
    private readonly ApplicationDbContext _context;

    public AuditTrailRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AuditTrail> GetByIdAsync(Guid id)
    {
        return await _context.AuditTrails.FindAsync(id);
    }

    public async Task<IEnumerable<AuditTrail>> GetAllAsync()
    {
        return await _context.AuditTrails.ToListAsync();
    }

    public async Task<AuditTrail> CreateAsync(AuditTrailDto audittrail)
    {
        var newAuditTrail = new AuditTrail
        {
            UserId = audittrail.UserId,
            Action = audittrail.Action
        };
        _context.AuditTrails.Add(newAuditTrail);
        await _context.SaveChangesAsync();
        return newAuditTrail;
    }

    public async Task<AuditTrail> UpdateAsync(AuditTrail audittrail)
    {
        _context.AuditTrails.Update(audittrail);
        await _context.SaveChangesAsync();
        return audittrail;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var audittrail = await GetByIdAsync(id);
        if (audittrail == null) return false;

        _context.AuditTrails.Remove(audittrail);
        await _context.SaveChangesAsync();
        return true;
    }
}