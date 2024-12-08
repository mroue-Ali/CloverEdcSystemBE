namespace CloverEdc.Core.DTOs;
public class Filter
{
    
    public int size { get; set; } = 0;
    public int offset { get; set; } = 10;
    public string? keyword { get; set; } = "";
    
    public Filter()
    {
        
    }
    
    public Filter(int pageNumber, int pageSize, string? search = "")
    {
        offset = pageNumber < 0 ? 0 : pageNumber;
        size = pageSize > 100 ? 100 : pageSize; // Limit max page size
        keyword = search ?? "";
    }
    
}   