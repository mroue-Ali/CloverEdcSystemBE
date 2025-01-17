using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfValue : EntityBase
{
    public Guid CrfFieldId { get; set; }
    public CrfField CrfField { get; set; }

    public Guid FileId { get; set; }
    public File File { get; set; }

    public string Value { get; set; }
    
    public Guid? DropDownValueId { get; set; }
    public DropDownOption DropDownValue { get; set; }
    public string Status { get; set; }
    public bool IsModified { get; set; }

    [JsonIgnore]
    [NotMapped]
    public ICollection<UpdateRequest> UpdateRequests { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<Query> Queries { get; set; }
    
}
