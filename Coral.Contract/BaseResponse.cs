namespace Coral.Contract;

public class BaseResponse<T> where T : class
{
    private readonly T? _data;
    private readonly bool _success = true;
    private readonly string _message;
    public bool success
    {
        get { return _success; }
    }

    public string Message
    {
        get { return _message; }
    }

    public T Data
    {
        get { return _data!; }
    }
    public BaseResponse(bool success, string message = "")
    {
        _success = success;
        _message = message;
    }
    public BaseResponse(T data, string message = "", bool success = true)
    {
        _data = data;
        _message = message;
        _success = success;
    }
}
