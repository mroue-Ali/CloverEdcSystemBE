using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Business.Services;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CloverEdc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly AuthHelper _authHelper;

    public AuthController(IUserService userService, AuthHelper authHelper)
    {
        _userService = userService;
        _authHelper = authHelper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
    {
        try
        {
            var user =  await _userService.RegisterUserAsync(userDto);
            var token = _authHelper.GenerateJwtToken(user);

            var response = new Response<object>(
                200,
                "User Registerd successfully",
                new
                {
                    Token = token,
                    User = user
                });

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new Response<string>(500, "An internal server error occurred : " + ex.Message));
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] RegisterUserDto userDto)
    {
        try
        {
           var user =  await _userService.RegisterUserAsync(userDto);
           var token = _authHelper.GenerateJwtToken(user);

            var response = new Response<object>(
                200,
                "User Created successfully",
                new
                {
                    User = user
                });

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new Response<string>(500, "An internal server error occurred : " + e.Message));
        }
    }

    // [Authorize (Roles = "SuperAdmin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] RegisterUserDto userDto)
    {
        try
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            return Ok(new Response<User>(200, "User updated successfully", updatedUser));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new Response<string>(404, "User not found"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new Response<string>(500, "An internal server error occurred : " + e.Message));
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginRequest)
    {
        try
        {
            var user = await _userService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized(new Response<string>(401, "Invalid username or password"));
            }

            var token = _authHelper.GenerateJwtToken(user);

            var response = new Response<object>(
                200,
                "Login successful",
                new
                {
                    Token = token,
                    User = user
                });

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new Response<string>(500, "An internal server error occurred : " + e.Message));
        }
    }


    [Authorize (Roles = "SuperAdmin")]
    [HttpGet("")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(new Response<object>(200, "Users retrieved successfully", users));
        }
        catch (Exception e)
        {
            return StatusCode(500, new Response<string>(500, "An internal server error occurred : " + e.Message));

        }
       
    }
    [Authorize (Roles = "SuperAdmin")]
    [HttpGet("get-users")]
    public async Task<IActionResult> GetAllUsers([FromQuery] Filter filter)
    {
        var validFilter = new Filter(filter.offset, filter.size,filter.keyword);
        // var roles = await _roleService.GetAllRolesAsync();
        var (items,count) = await _userService.GetFilteredUsers(validFilter);
        return Ok(new Response<IEnumerable<User>>(200, "Users retrieved successfully", items,count));
    }
}