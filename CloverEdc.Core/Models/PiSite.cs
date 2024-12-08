using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class PiSite : EntityBase
{
    public Guid PiId { get; set; }
    [JsonIgnore] 
    public Pi Pi { get; set; }

    public Guid SiteId { get; set; }
    public Site Site { get; set; }
}
