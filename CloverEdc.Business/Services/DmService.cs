using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class DmService : IDmService
{
    private readonly IDmRepository _dmRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IStudyRepository _studyRepository;
    private readonly IUserRepository _userRepository;

    public DmService(IDmRepository dmRepository,IRoleRepository roleRepository,IStudyRepository studyRepository,IUserRepository userRepository)
    {
        _dmRepository = dmRepository;
        _roleRepository = roleRepository;
        _studyRepository = studyRepository;
        _userRepository = userRepository;
    }

    public async Task<Dm> GetDmByIdAsync(Guid id)
    {
        return await _dmRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Dm>> GetAllDmsAsync()
    {
        return await _dmRepository.GetAllAsync();
    }

    public async Task<Dm> CreateDmAsync(RegisterUserDto dm,Guid studyId)
    {
        var study = await _studyRepository.GetByIdAsync(studyId);
        if (study == null) return null;
        var role = await _roleRepository.GetRoleByNameAsync("DM");
        var newUser = new User
        {
            UserName = dm.UserName,
            FirstName = dm.FirstName,
            LastName = dm.LastName,
            Password = dm.Password,
            Email = dm.Email,
            RoleId = role.Id,
            StudyId = studyId
        };
         await _userRepository.AddUserAsync(newUser);
         var newDm = new DmDto
         {
             UserId = newUser.Id
         };
        return await _dmRepository.CreateAsync(newDm);
    }

    public async Task<Dm> UpdateDmAsync(Guid id, DmDto dm)
    {
        var existingDm = await _dmRepository.GetByIdAsync(id);
        
        if (existingDm == null) throw new KeyNotFoundException("Dm not found");
        var dtoProperties = typeof(DmDto).GetProperties();
        var entityProperties = typeof(Dm).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(dm);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingDm, value);
            }
        }
        var user =  _userRepository.GetById(existingDm.UserId);
        user.Email = dm.Email;
        user.FirstName = dm.FirstName;
        user.LastName = dm.LastName;
        user.UserName = dm.UserName;
        _userRepository.Update(user);
        
        return await _dmRepository.UpdateAsync(existingDm);
    }

    public async Task<bool> DeleteDmAsync(Guid id)
    {
        return await _dmRepository.DeleteAsync(id);
    }
    
    public async Task<IEnumerable<Dm>> GetDmsByStudyIdAsync(Guid studyId)
    {
        return await _dmRepository.GetDmsByStudyIdAsync(studyId);
    }
}