using System;

public class ServerRequest<T> : IRequest
{
    public string Url;
    public Action<T> Success;
    public Action<string> Failure;

    public ServerRequest(string url, Action<T> success, Action<string> failure)
    {
        Url = url;
        Success = success;
        Failure = failure;
    }
}
