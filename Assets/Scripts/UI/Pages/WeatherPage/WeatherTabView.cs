using UnityEngine;
using UnityEngine.UI;

public class WeatherTabView : BaseTabView
{
    [SerializeField] private Image icon;
    [SerializeField] private Text title;

    public void SetWeather(Sprite weatherIcon, string weatherTitle)
    {
        icon.sprite = weatherIcon;
        title.text = weatherTitle;
    }
}
