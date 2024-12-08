namespace CloverEdc.Core.DTOs;

public class CrfFileDto
{
    public string Name { get; set; }
    public Guid? RequiredFileId { get; set; }
    public Guid CrfTemplateId { get; set; }
}