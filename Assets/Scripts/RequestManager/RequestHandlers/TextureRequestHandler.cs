using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TextureRequestHandler : IRequestHandler<Texture2D>
{
    public IEnumerator HandleRequest(ServerRequest<Texture2D> request)
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