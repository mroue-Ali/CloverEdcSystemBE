namespace CloverEdc.Core.Models;

public class Lock : EntityBase
{
    public Guid StudyId { get; set; }
    public Study Study { get; set; }

    public Guid LockedBy { get; set; }
    public User User { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;
}
