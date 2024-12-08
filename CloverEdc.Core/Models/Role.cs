using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Role : EntityBase
{
    public string Name { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<User> Users { get; set; }
}
