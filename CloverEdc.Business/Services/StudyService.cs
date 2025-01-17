using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;

public class StudyService : IStudyService
{
    private readonly IStudyRepository _studyRepository;
    private readonly AuthHelper _authHelper;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public StudyService(IStudyRepository studyRepository, IRoleRepository roleRepository, AuthHelper authHelper,
        IUserRepository userRepository)
    {
        _studyRepository = studyRepository;
        _roleRepository = roleRepository;
        _authHelper = authHelper;
        _userRepository = userRepository;
    }

    public async Task<Study> GetStudyByIdAsync(Guid id)
    {
        return await _studyRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Study>> GetAllStudiesAsync()
    {
        return await _studyRepository.GetAllAsync();
    }
 public async  Task<(IEnumerable<Study>, int)> GetPagedFilteredItemsAsync(Filter filter)
    {
        return await _studyRepository.GetPagedFilteredItemsAsync(filter);
    }

    public async Task<Study> CreateStudyAsync(StudyDto study)
    {
        return await _studyRepository.CreateAsync(study);
    }

    public async Task<Study> UpdateStudyAsync(Guid id, StudyDto study)
    {
        var existingStudy = await _studyRepository.GetByIdAsync(id);
        if (existingStudy == null) throw new KeyNotFoundException("Study not found");

        var dtoProperties = typeof(StudyDto).GetProperties();
        var entityProperties = typeof(Study).GetProperties();

        foreach (var dtoProp in dtoProperties)
        {
            var value = dtoProp.GetValue(study);
            if (value != null)
            {
                var entityProp = entityProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                entityProp?.SetValue(existingStudy, value);
            }
        }

        return await _studyRepository.UpdateAsync(existingStudy);
    }

    public async Task<bool> DeleteStudyAsync(Guid id)
    {
        return await _studyRepository.DeleteAsync(id);
    }

    public async Task<User> AddAdminToStudyAsync(Guid studyId, RegisterUserDto user)
    {
        var existingStudy = await _studyRepository.GetByIdAsync(studyId);
        if (existingStudy == null) throw new KeyNotFoundException("Study not found");
        var role = await _roleRepository.GetRoleByNameAsync("Admin");
        if (role == null)
        {
            throw new Exception("Role not found");
        }

        var roleId = role.Id;

        var Password = _authHelper.CreatePasswordHash(user.Password);
        var RefreshToken = _authHelper.GenerateRefreshToken();
        var newUser = new User(user.UserName, user.UserName, user.UserName, user.Email, Password, roleId, studyId);

        await _userRepository.AddUserAsync(newUser);
        return newUser;
    }
}