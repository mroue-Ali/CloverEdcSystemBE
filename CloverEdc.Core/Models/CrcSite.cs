using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrcSite : EntityBase
{
    public Guid CrcId { get; set; }
    [JsonIgnore] 
    public Crc Crc { get; set; }

    public Guid SiteId { get; set; }
    public Site Site { get; set; }
}
