using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfFile : EntityBase
{
    public string Name { get; set; }
    public int Index { get; set; }
    public Guid? RequiredFileId { get; set; }
    public Guid? ParentFileId { get; set; }

    public Guid CrfTemplateId { get; set; }
    public CrfTemplate CrfTemplate { get; set; }

    [JsonIgnore] [NotMapped] public ICollection<File> Files { get; set; }
    [JsonIgnore] [NotMapped] public ICollection<CrfField> CrfFields { get; set; }

    [NotMapped] public CrfFile? ParentFile { get; set; }

    // [JsonIgnore]
    [NotMapped] public ICollection<CrfFile>? SubFiles { get; set; }
}