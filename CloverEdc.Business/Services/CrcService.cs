using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class CrcService : ICrcService
{
    private readonly ICrcRepository _crcRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly AuthHelper _authHelper;

    public CrcService(ICrcRepository crcRepository, IUserRepository userRepository, AuthHelper authHelper,
        IRoleRepository roleRepository)
    {
        _crcRepository = crcRepository;
        _userRepository = userRepository;
        _authHelper = authHelper;
        _roleRepository = roleRepository;
    }


    public async Task<Crc> GetCrcByIdAsync(Guid id)
    {
        return await _crcRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Crc>> GetAllCrcsAsync()
    {
        return await _crcRepository.GetAllAsync();
    }

    public async Task<Crc> CreateCrcAsync(CrcDto crc, Guid studyId)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(crc.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }

        var role = await _roleRepository.GetRoleByNameAsync("CRC");
        if (role == null)
        {
            throw new Exception("Role not found");
        }

        var roleId = role.Id;

        var Password = _authHelper.CreatePasswordHash(crc.Password);
        var RefreshToken = _authHelper.GenerateRefreshToken();
        var user = new User(crc.UserName, crc.UserName, crc.UserName, crc.Email, Password, roleId,studyId);
        
        await _userRepository.AddUserAsync(user);

        crc.UserId = user.Id;

        var newCrc = await _crcRepository.CreateAsync(crc);
        
        // foreach (var crcSite in crc.SiteIds)
        // {
        //     var newCrcSite = new CrcSiteDto
        //     {
        //         SiteId = crcSite,
        //         CrcId = newCrc.Id
        //     };
        //     await _crcSiteRepository.CreateAsync(newCrcSite);
        // }

        return newCrc;
    }

    public async Task<Crc> UpdateCrcAsync(Guid id, CrcDto crc)
    {
        var existingCrc = await _crcRepository.GetByIdAsync(id);
        if (existingCrc == null) throw new KeyNotFoundException("Crc not found");
        
        var dtoProperties = typeof(CrcDto).GetProperties();
        var entityProperties = typeof(Crc).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(crc);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingCrc, value);
            }
        }
        
        // await _crcSiteRepository.DeleteByCrcIdAsync(id);
       
        // foreach (var siteId in crc.SiteIds)
        // {
            // var newCrcSite = new CrcSiteDto
            // {
                // SiteId = siteId,
                // CrcId = id
            // };
            // await _crcSiteRepository.CreateAsync(newCrcSite);
        // }
        
        var user =  _userRepository.GetById(existingCrc.UserId);
        user.Email = crc.Email;
        user.FirstName = crc.FirstName;
        user.LastName = crc.LastName;
        user.UserName = crc.UserName;
        _userRepository.Update(user);
        return await _crcRepository.UpdateAsync(existingCrc);
    }

    public async Task<bool> DeleteCrcAsync(Guid id)
    {
        return await _crcRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Crc>> GetCrcsByStudyIdAsync(Guid studyId)
    {
        return await _crcRepository.GetCrcsByStudyIdAsync(studyId);
    }
    public async Task<(IEnumerable<Crc>, int)> GetCrcsByStudyIdAsync(Guid studyId,Filter filter)
    {
        return await _crcRepository.GetCrcsByStudyIdAsync(studyId,filter);
    }
}