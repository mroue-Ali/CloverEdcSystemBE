using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrcCrf : EntityBase
{
    public Guid CrfId { get; set; }
    public Crf Crf { get; set; }
    public Guid CrcId { get; set; }
    public Crc Crc { get; set; }
}