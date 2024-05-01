

public class Resault<T>
{
    public bool IsSucceed { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public Resault(bool isSucceed, string message, T data)
    {
        IsSucceed = isSucceed;
        Message = message;
        Data = data;
    }
}