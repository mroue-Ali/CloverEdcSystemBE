namespace CloverEdc.Core.DTOs;

public class CrfPageDto
{
    public string Name { get; set; }
    public Guid CrfFileId { get; set; }
    public Guid? RequiredPageId { get; set; }
}