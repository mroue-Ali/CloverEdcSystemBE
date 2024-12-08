using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CloverEdc.Business.Interfaces;

public interface  IUserService
{
    Task<(string accessToken, Guid? refreshToken)> RefreshTokenAsync(Guid refreshToken);
    Task<User> AuthenticateAsync(string email, string password);
    Task<User> RegisterUserAsync(RegisterUserDto user);
    Task AddUserAsync(RegisterUserDto user);
    Task<IEnumerable<User>> GetAllUsersAsync();
    List<User> GetAllUsers();
    Task<(IEnumerable<User>, int)> GetFilteredUsers(Filter filter);
    //UpdateUserAsync
    Task<User> UpdateUserAsync(Guid id,RegisterUserDto user);
    
}