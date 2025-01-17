using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Crc : EntityBase
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    // [JsonIgnore]
    [NotMapped]
    public ICollection<CrcCrf> CrcCrfs { get; set; }
}