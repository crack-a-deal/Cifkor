using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class RequestHandlers
{
    public static IEnumerator HandleTextRequest(ServerRequest<string> request)
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

    public static IEnumerator HandleTextureRequest(ServerRequest<Texture2D> request)
    {
        using (UnityWebRequest web = UnityWebRequestTexture.GetTexture(request.Url))
        {
            yield return web.SendWebRequest();

            if (web.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(web);
                request.Success?.Invoke(texture);
            }
            else
            {
                request.Failure?.Invoke(web.error);
            }
        }
    }
}

