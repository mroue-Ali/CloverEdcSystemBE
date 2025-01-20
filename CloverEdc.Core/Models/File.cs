using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class File : EntityBase
{

    public Guid CrfFileId { get; set; }
    public CrfFile CrfFile { get; set; }
    public int Index { get; set; }

    public Guid CrfId { get; set; }
    public Crf Crf { get; set; }
    
    public DateTime DateDone { get; set; }
    [JsonIgnore]
    [NotMapped] 
    public ICollection<CrfValue> CrfValues { get; set; }

    
}