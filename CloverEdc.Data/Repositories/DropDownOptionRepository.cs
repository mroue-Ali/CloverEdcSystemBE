using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.EntityFrameworkCore;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Repositories;
public class DropDownOptionRepository : BaseRepository<DropDownOption>,IDropDownOptionRepository
{
    private readonly ApplicationDbContext _context;

    public DropDownOptionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<DropDownOption> AddAsync(DropDownOption dropDownOption)
    {
        await _context.DropDownOptions.AddAsync(dropDownOption);
        await _context.SaveChangesAsync();
        return dropDownOption;
    }
  
}
