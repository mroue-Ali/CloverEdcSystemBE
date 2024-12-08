using System.ComponentModel.DataAnnotations.Schema;

namespace CloverEdc.Core.Models;

public class Pi : EntityBase
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    // public Guid SiteId { get; set; }
    // public Site Site { get; set; }
    
    // [JsonIgnore]
    [NotMapped]
    public ICollection<PiSite> PiSites { get; set; }
}