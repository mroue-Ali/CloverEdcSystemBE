namespace CloverEdc.Core.DTOs;

public class Response<T>
{
    public int Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public int? Count { get; set; }

    public Response(int status, string message, T data = default, int? count = null)
    {
        Status = status;
        Message = message;
        Data = data;
        Count = count;
    }
}