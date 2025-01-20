using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfTemplate : EntityBase
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid StudyId { get; set; }
    public Study Study { get; set; }
    
    
    [JsonIgnore]
    [NotMapped]
    public ICollection<Crf> Crfs { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrfFile> CrfFiles { get; set; }
}
