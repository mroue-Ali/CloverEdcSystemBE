using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Study : EntityBase
{
    public string Name { get; set; }
    public string Status { get; set; }

    [NotMapped] public bool HasAdmin { get; set; }
    public Guid ProtocolId { get; set; }
    public Protocol Protocol { get; set; }
    [JsonIgnore] [NotMapped] public ICollection<Site> Sites { get; set; }
    [JsonIgnore] [NotMapped] public ICollection<Lock> Locks { get; set; }
    [NotMapped] public CrfTemplate CrfTemplate { get; set; }
}