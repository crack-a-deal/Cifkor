using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RequestManager : MonoBehaviour
{
    private readonly Dictionary<Type, Func<IRequest, IEnumerator>> _handlers = new Dictionary<Type, Func<IRequest, IEnumerator>>();

    private ConcurrentQueue<IRequest> _requests = new ConcurrentQueue<IRequest>();
    private bool _isProcessing;

    private void Awake()
    {
        _handlers.Add(typeof(string), request => RequestHandlers.HandleTextRequest((ServerRequest<string>)request));
        _handlers.Add(typeof(Texture2D), request => RequestHandlers.HandleTextureRequest((ServerRequest<Texture2D>)request));
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void EnqueueRequest<T>(ServerRequest<T> request)
    {
        if (_handlers.TryGetValue(typeof(T), out Func<IRequest, IEnumerator> handler))
        {
            print($"added new request {request.Url}");
            _requests.Enqueue(request);
            if (!_isProcessing)
            {
                StartCoroutine(ProcessRequests());
            }
        }
        else
        {
            Debug.LogError($"No handler found for type {typeof(T)}");
        }
    }

    public void Clear()
    {
        _requests.Clear();
    }

    private IEnumerator ProcessRequests()
    {
        //Debug.Log("processing..");
        _isProcessing = true;
        while (_requests.Count > 0)
        {
            _requests.TryDequeue(out IRequest request);
            if (_handlers.TryGetValue(request.GetType().GetGenericArguments()[0], out var handler))
            {
                yield return handler(request);
            }
        }
        //Debug.Log("ended");
        _isProcessing = false;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUILayout.Label(_requests.Count.ToString());
    }
}
