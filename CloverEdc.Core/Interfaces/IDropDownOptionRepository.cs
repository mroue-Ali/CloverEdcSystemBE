using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;
    
public interface IDropDownOptionRepository : IBaseRepository<DropDownOption>
{
    Task<DropDownOption> AddAsync(DropDownOption dropDownOption);
}
