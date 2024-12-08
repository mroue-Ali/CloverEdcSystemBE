using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CloverEdc.Core.Models;

public class User : EntityBase
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public Guid RefreshToken { set; get; } = Guid.NewGuid();
    public Role Role { get; set; }
    public Guid? StudyId { get; set; }
    public Study? Study { get; set; }

    public User()
    {
    }
    public User(string userName,string firstName,string lastName, string email, string password, Guid roleId ,Guid? studyId=null)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        RoleId = roleId;
        StudyId = studyId;
    }
   

    public void UpdateUser(User newUser)
    {
        UserName = newUser.UserName;
        Email = newUser.Email;
        Password = newUser.Password;
        RoleId = newUser.RoleId;
    }

    public void GenerateRefreshToken()
    {
        RefreshToken = Guid.NewGuid();
    }
}