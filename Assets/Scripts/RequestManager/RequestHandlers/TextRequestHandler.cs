using System.Collections;
using UnityEngine.Networking;

public class TextRequestHandler : IRequestHandler<string>
{
    public IEnumerator HandleRequest(ServerRequest<string> request)
    {
        using (UnityWebRequest web = UnityWebRequest.Get(request.Url))
        {
            yield return web.SendWebRequest();

            if (web.result == UnityWebRequest.Result.Success)
            {
                request.Success?.Invoke(web.downloadHandler.text);
            }
            else
            {
                request.Failure?.Invoke(web.error);
            }
        }
    }
}
