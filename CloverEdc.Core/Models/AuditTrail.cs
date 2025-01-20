namespace CloverEdc.Core.Models;

public class AuditTrail : EntityBase
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public string Action { get; set; }
    public DateTime Timestamp { get; set; } =DateTime.Now;
}
