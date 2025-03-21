using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour
{
    public event Action<TabButton> TabSelected;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        TabSelected?.Invoke(this);
    }
}
