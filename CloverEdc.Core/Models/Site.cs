using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Site : EntityBase
{
    public string Name { get; set; }
    public string Location { get; set; }

    public Guid StudyId { get; set; }
    public Study Study { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrcSite> CrcSites { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<DmSite> DmSites { get; set; }  
    
    [NotMapped]
    public bool hasPi { get; set; }
}
