namespace CloverEdc.Core.Models;

public class DmSite : EntityBase
{
    public Guid DmId { get; set; }
    public Dm Dm { get; set; } // Assuming `User` is reused for Data Managers (DM)

    public Guid SiteId { get; set; }
    public Site Site { get; set; }
}
