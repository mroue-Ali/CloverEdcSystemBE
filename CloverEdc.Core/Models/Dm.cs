using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Dm : EntityBase
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    [JsonIgnore]
    [NotMapped]
    public ICollection<DmQuery> DmQueries { get; set; }
}