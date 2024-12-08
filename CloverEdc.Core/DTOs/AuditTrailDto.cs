namespace CloverEdc.Core.DTOs;

public class AuditTrailDto
{
    public Guid UserId { get; set; }
    public string Action { get; set; }
}