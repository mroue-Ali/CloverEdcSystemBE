namespace CloverEdc.Core.Models;

public class UpdateRequest : EntityBase
{
    public Guid CrfValueId { get; set; }
    public CrfValue CrfValue { get; set; }

    public string Status { get; set; }
    public string Reason { get; set; }
    public string NewValue { get; set; }

    
    public Guid CrcId { get; set; }
    public Crc Crc { get; set; }

    // public Guid UserId { get; set; }
    // public User User { get; set; } // User requesting the update
}
