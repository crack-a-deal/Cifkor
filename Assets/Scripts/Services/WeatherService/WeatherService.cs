using System;
using UnityEngine;

public class WeatherService : IWeatherService
{
    private const string API_URL = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";

    private readonly RequestManager _requestManager;

    public WeatherService(RequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public void FetchWeather(Action<WeatherData> onSuccess, Action<string> onError)
    {
        ServerRequest<string> weatherRequest = new ServerRequest<string>(API_URL, response =>
        {
            WeatherResponse weatherResponse = WeatherParser.Parse(response);
            ForecastPeriod todayWeatherPeriod = weatherResponse.Properties.Periods[0];


            ServerRequest<Texture2D> iconRequest = new ServerRequest<Texture2D>(todayWeatherPeriod.IconURL, weatherIcon =>
            {
                Sprite ic = Sprite.Create(weatherIcon, new Rect(0, 0, weatherIcon.width, weatherIcon.height), new Vector2(0.5f, 0.5f));
                WeatherData todayWeatherData = new WeatherData()
                {
                    Temperature = todayWeatherPeriod.Temperature,
                    TemperatureUnit = todayWeatherPeriod.TemperatureUnit,
                    Icon = ic,
                };

                onSuccess?.Invoke(todayWeatherData);
            }, imageError =>
            {
                onError?.Invoke("Ошибка получения изображения погоды: " + imageError);
            });

            _requestManager.EnqueueRequest(iconRequest);

        }, errorText =>
        {
            onError?.Invoke("Ошибка получения погоды: " + errorText);
        }
        );

        _requestManager.EnqueueRequest(weatherRequest);
    }
}
