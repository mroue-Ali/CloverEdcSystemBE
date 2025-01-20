using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CloverEdc.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly AuthHelper _authHelper;

    public UserService( IUserRepository userRepository, AuthHelper authHelper)
    {
        _authHelper = authHelper;
        _userRepository = userRepository;
    }


    public async Task<User> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null)
        {
            return null;
        }

        var isCorrectPass = _authHelper.VerifyPasswordHash(password, user.Password);
        if (!isCorrectPass)
        {
            return null;
        }
        var refreshToken = _authHelper.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        _userRepository.Update(user);
        
        return user;
    }
    public async Task<(string accessToken, Guid? refreshToken)> RefreshTokenAsync(Guid refreshToken)
    {
        var user = await _userRepository.GetUserByRefreshTokenAsync(refreshToken);
        if (user == null)
            return (null, null);

        var newAccessToken = _authHelper.GenerateJwtToken(user);
        var newRefreshToken = _authHelper.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        _userRepository.Update(user);

        return (newAccessToken, newRefreshToken);
    }

    public async Task<User> RegisterUserAsync(RegisterUserDto rUser)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(rUser.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        if (!Guid.TryParse(rUser.RoleId,out Guid roleId))
        {
            throw new Exception("Role Id is not in correct format");
        }
        
        var Password= _authHelper.CreatePasswordHash(rUser.Password);
        var user = new User(rUser.UserName,rUser.UserName,rUser.UserName,rUser.Email,Password,roleId);
        await _userRepository.AddUserAsync(user);
        user = _userRepository.GetUserByEmailAsync(rUser.Email).Result;
        return user;
    }
  public async Task AddUserAsync(RegisterUserDto rUser)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(rUser.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        if (!Guid.TryParse(rUser.RoleId,out Guid roleId))
        {
            throw new Exception("Role Id is not in correct format");
        }
        
      
        var Password= _authHelper.CreatePasswordHash(rUser.Password);
        var RefreshToken = _authHelper.GenerateRefreshToken();
        var user = new User(rUser.UserName,rUser.UserName,rUser.UserName,rUser.Email,Password,roleId);
        await _userRepository.AddUserAsync(user);
        
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }
    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
    public async Task<(IEnumerable<User>,int)> GetFilteredUsers(Filter filter)
    {
        var (roles, totalItems) = await _userRepository.GetFilteredUsers(filter);

        return (roles, totalItems);
    }
    
    public async Task<User> UpdateUserAsync(Guid id,RegisterUserDto user)
    {
        
        var existingUser = _userRepository.GetById(id);
        if (existingUser == null) throw new KeyNotFoundException("User not found");
        
        var dtoProperties = typeof(RegisterUserDto).GetProperties();
        var entityProperties = typeof(User).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(user);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingUser, value);
            }
        }
        _userRepository.Update(existingUser);
        return existingUser;
    }
}