namespace CloverEdc.Core.DTOs;

public class CrcDto
{
    
    public Guid? UserId { get; set; }
    
    public string UserName { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string? Password { get; set; }
    
    public List<Guid>? SiteIds { get; set; }
    
}