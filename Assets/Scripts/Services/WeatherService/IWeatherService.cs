using System;

public interface IWeatherService
{
    void FetchWeather(Action<WeatherData> successCallback, Action<string> failureCallback);
}
