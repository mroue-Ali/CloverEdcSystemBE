using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfFile : EntityBase
{
    public string Name { get; set; }
    public Guid? RequiredFileId { get; set; }
    
    public Guid CrfTemplateId { get; set; }
    public CrfTemplate CrfTemplate { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrfPage> CrfPages { get; set; }

}
