using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null) return NotFound(new Response<string>(404, "Role not found"));
        
        return Ok(new Response<Role>(200, "Role retrieved successfully", role));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size, filter.keyword);
        // var roles = await _roleService.GetAllRolesAsync();
        var (roles,count) = await _roleService.GetPagedRolesAsync(validFilter);
        return Ok(new Response<IEnumerable<Role>>(200, "Roles retrieved successfully", roles,count));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleDto role)
    {
        var createdRole = await _roleService.CreateRoleAsync(role);
        return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, 
            new Response<Role>(201, "Role created successfully", createdRole));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleDto role)
    {
        try
        {
            var updatedRole = await _roleService.UpdateRoleAsync(id, role);
            return Ok(new Response<Role>(200, "Role updated successfully", updatedRole));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "Role not found"));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var isDeleted = await _roleService.DeleteRoleAsync(id);
        if (!isDeleted) return NotFound(new Response<string>(404, "Role not found"));
        
        return Ok(new Response<string>(200, "Role deleted successfully"));
    }

    
}