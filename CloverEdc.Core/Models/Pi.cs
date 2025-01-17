using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Pi : EntityBase
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    // [JsonIgnore]
    [NotMapped]
    public ICollection<Site> Sites { get; set; }
    [NotMapped]
    public string SitesStr { get; set; }
}