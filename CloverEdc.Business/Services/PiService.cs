using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class PiService : IPiService
{
    private readonly IPiRepository _piRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly AuthHelper _authHelper;

    public PiService(IPiRepository piRepository, IUserRepository userRepository,IRoleRepository roleRepository, AuthHelper authHelper)
    {
        _piRepository = piRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _authHelper = authHelper;
    }

    public async Task<Pi> GetPiByIdAsync(Guid id)
    {
        return await _piRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Pi>> GetAllPisAsync()
    {
        return await _piRepository.GetAllAsync();
    }

    public async Task<Pi> CreatePiAsync(PiDto pi,Guid studyId)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(pi.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        var role = await _roleRepository.GetRoleByNameAsync("PI");
        
        if (role == null)
        {
            throw new Exception("Role not found");
        }

        var roleId = role.Id;

        var Password = _authHelper.CreatePasswordHash(pi.Password);
        var RefreshToken = _authHelper.GenerateRefreshToken();
        var user = new User(pi.UserName, pi.UserName, pi.UserName, pi.Email, Password, roleId,studyId);
        
        await _userRepository.AddUserAsync(user);

        pi.UserId = user.Id;

        var newCrc = await _piRepository.CreateAsync(pi);
        
        // foreach (var crcSite in pi.SiteIds)
        // {
        //     var newCrcSite = new PiSiteDto
        //     {   
        //         SiteId = crcSite,
        //         PiId = newCrc.Id
        //     };
        //     await _piSiteRepository.CreateAsync(newCrcSite);
        // }

        return newCrc;
    }

    public async Task<Pi> UpdatePiAsync(Guid id, PiDto pi)
    {
        var existingPi = await _piRepository.GetByIdAsync(id);
        if (existingPi == null) throw new KeyNotFoundException("Pi not found");
        
        var dtoProperties = typeof(PiDto).GetProperties();
        var entityProperties = typeof(Pi).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(pi);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingPi, value);
            }
        }
        
        // await _piSiteRepository.DeleteByPiIdAsync(id);
       
        // foreach (var siteId in pi.SiteIds)
        // {
        //     var newCrcSite = new PiSiteDto
        //     {
        //         SiteId = siteId,
        //         PiId = id
        //     };
        //     await _piSiteRepository.CreateAsync(newCrcSite);
        // }
        //update the user info on the users table
        var user =  _userRepository.GetById(existingPi.UserId);
        user.Email = pi.Email;
        user.FirstName = pi.FirstName;
        user.LastName = pi.LastName;
        user.UserName = pi.UserName;
        _userRepository.Update(user);
        
        return await _piRepository.UpdateAsync(existingPi);
    }

    public async Task<bool> DeletePiAsync(Guid id)
    {
        return await _piRepository.DeleteAsync(id);
    }
    
    public async Task<IEnumerable<Pi>> GetPisByStudyIdAsync(Guid studyId)
    {
        return await _piRepository.GetPisByStudyIdAsync(studyId);
    }
    public async Task<(IEnumerable<Pi>, int)> GetPisByStudyIdAsync(Guid studyId,Filter filter)
    {
        return await _piRepository.GetPisByStudyIdAsync(studyId,filter);
    }

    
}