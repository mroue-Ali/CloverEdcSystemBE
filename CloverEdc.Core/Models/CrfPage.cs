using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfPage : EntityBase
{
    public string Name { get; set; }

    public Guid CrfFileId { get; set; }
    public CrfFile CrfFile { get; set; }
    public Guid? RequiredPageId { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrfField> CrfFields { get; set; }
}
