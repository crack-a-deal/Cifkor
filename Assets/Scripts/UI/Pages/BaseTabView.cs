using System;
using UnityEngine;

public class BaseTabView : MonoBehaviour, ITabView
{
    public event Action TabOpened;
    public event Action TabClosed;

    public void Show()
    {
        gameObject.SetActive(true);
        TabOpened?.Invoke();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        TabClosed?.Invoke();
    }
}
