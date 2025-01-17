using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Patient : EntityBase
{
    public string Name { get; set; }
    public string Code { get; set; }

    public Guid SiteId { get; set; }
    public Site Site { get; set; }

    public string? RandomizationArm { get; set; } // Nullable
    [JsonIgnore]
    [NotMapped]
    public ICollection<Crf> Crfs { get; set; }
}
