using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;

public class StudyRepository : BaseRepository<Study>, IStudyRepository
{
    private readonly ApplicationDbContext _context;

    public StudyRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Study> GetByIdAsync(Guid id)
    {
        return await _context.Studies.FindAsync(id);
    }

    public async Task<IEnumerable<Study>> GetAllAsync()
    {
        return await _context.Studies.Include(x=>x.Protocol).ToListAsync();
        // var studies = await _context.Studies
            // .Include(x => x.Protocol)
            // .ToListAsync();

        // var studyDtos = studies.Select(study => new Study
        // {
            // Id = study.Id,
            // Name = study.Name,
            // Protocol = study.Protocol,
            // HasAdmin = _context.Users.Any(u => u.Role.Name == "Admin" && u.StudyId == study.Id)
        // });
        // return studyDtos;
    }

    public async Task<(IEnumerable<Study>, int)> GetPagedFilteredItemsAsync(Filter filter)
    {
        var query = _context.Studies.Include(x=>x.Protocol).AsQueryable();
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
   
    public async Task<Study> CreateAsync(StudyDto study)
    {
        var newStudy = new Study
        {
            Name = study.Name?? "New Study",
            Status = study.Status?? "Pending",
            ProtocolId = study.ProtocolId?? Guid.Empty,
        };
        _context.Studies.Add(newStudy);
        await _context.SaveChangesAsync();
        return newStudy;
    }

    public async Task<Study> UpdateAsync(Study study)
    {
        _context.Studies.Update(study);
        await _context.SaveChangesAsync();
        return study;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var study = await GetByIdAsync(id);
        if (study == null) return false;

        _context.Studies.Remove(study);
        await _context.SaveChangesAsync();
        return true;
    }
        
    public async Task<User> AddAdminToStudyAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}