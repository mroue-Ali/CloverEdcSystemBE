using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Crf : EntityBase
{
    public Guid CrcId { get; set; }
    public Crc Crc { get; set; }

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    public Guid CrfTemplateId { get; set; }
    public CrfTemplate CrfTemplate { get; set; }

    [JsonIgnore]
    [NotMapped]
    public ICollection<File> Files { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrcCrf> CrcCrfs { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public ICollection<AdverseEvent> AdverseEvents { get; set; }
    
    
}
