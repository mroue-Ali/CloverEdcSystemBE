using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Query : EntityBase
{
    public Guid CrfValueId { get; set; }
    public CrfValue CrfValue { get; set; }

    public Guid DmId { get; set; }
    public Dm Dm { get; set; } // Data Manager issuing the query

    public string QueryText { get; set; }
    public string Status { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public ICollection<DmQuery> DmQueries { get; set; }
    
}
