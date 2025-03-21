using System.Collections;

public interface IRequestHandler<T>
{
    IEnumerator HandleRequest(ServerRequest<T> request);
}
