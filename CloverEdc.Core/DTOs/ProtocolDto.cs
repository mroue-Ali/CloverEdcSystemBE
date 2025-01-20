using CloverEdc.Core.TagHelpers;

namespace CloverEdc.Core.DTOs;

using System.Text.Json.Serialization;

public class ProtocolDto
{
    public string? Name { get; set; }
    public int? NumOfVisits { get; set; }
    [JsonConverter(typeof(StringToNullableBoolConverter))]
    public bool? Randomization { get; set; } 
}

