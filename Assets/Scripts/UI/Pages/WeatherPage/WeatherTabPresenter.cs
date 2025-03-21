using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WeatherTabPresenter : BaseTabPresenter
{
    private const int WEATHER_REQUEST_INTERVAL = 5000;

    private readonly RequestManager _requestManager;
    private readonly IWeatherService _weatherService;
    private readonly WeatherTabView _weatherView;

    private CancellationTokenSource _cts = new CancellationTokenSource();

    public WeatherTabPresenter(RequestManager requestManager, IWeatherService weatherService, ITabView tabView) : base(tabView)
    {
        _requestManager = requestManager;
        _weatherService = weatherService;
        _weatherView = (WeatherTabView)tabView;
    }

    protected override void TabView_OnTabOpened()
    {
        Debug.Log("Weather page opened");

        _cts = new CancellationTokenSource();
        StartWeatherUpdates(_cts.Token);
    }

    protected override void TabView_OnTabClosed()
    {
        Debug.Log("Weather page closed");
        _cts.Cancel();
    }

    private async void StartWeatherUpdates(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            _weatherService.FetchWeather(UpdateWeatherView, x => { Debug.LogError(x); });
            await Task.Delay(WEATHER_REQUEST_INTERVAL, token);
        }
    }

    private void UpdateWeatherView(WeatherData weatherData)
    {
        _weatherView.SetWeather(weatherData.Icon, $"Сегодня — {weatherData.Temperature}{weatherData.TemperatureUnit}");
    }
}
