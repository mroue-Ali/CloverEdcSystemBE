using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Core.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByRefreshTokenAsync(Guid refreshToken);
    Task AddUserAsync(User user);

    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<(IEnumerable<User>, int)> GetFilteredUsers(Filter filter);
}
