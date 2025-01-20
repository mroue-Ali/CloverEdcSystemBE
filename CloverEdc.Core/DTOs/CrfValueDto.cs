namespace CloverEdc.Core.DTOs;

public class CrfValueDto
{
    public Guid CrfFieldId { get; set; }
    public Guid CrfId { get; set; }
    public Guid? DropDownValueId { get; set; }
    public Guid FileId { get; set; }

    public string Value { get; set; }
    public string Status { get; set; } = "Pending";
    public bool IsModified { get; set; } = false;
}