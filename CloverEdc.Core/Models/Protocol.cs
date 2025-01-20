using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Protocol : EntityBase
{
    public string Name { get; set; }
    public int NumOfVisits { get; set; }
    public bool Randomization { get; set; }
    [JsonIgnore]
    [NotMapped]

    public ICollection<Study>? Studies { get; set; }
}
