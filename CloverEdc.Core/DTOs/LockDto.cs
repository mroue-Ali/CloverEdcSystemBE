namespace CloverEdc.Core.DTOs;

public class LockDto
{
    public Guid StudyId { get; set; }
    public Guid LockedBy { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;
}