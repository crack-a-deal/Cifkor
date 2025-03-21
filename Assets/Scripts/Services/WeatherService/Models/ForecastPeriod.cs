using Newtonsoft.Json;

public class ForecastPeriod
{
    [JsonProperty("number")]
    public int Number;

    [JsonProperty("name")]
    public string Name;

    [JsonProperty("startTime")]
    public string StartTime;

    [JsonProperty("endTime")]
    public string EndTime;

    [JsonProperty("isDaytime")]
    public bool IsDaytime;

    [JsonProperty("temperature")]
    public float Temperature;

    [JsonProperty("temperatureUnit")]
    public string TemperatureUnit;

    [JsonProperty("icon")]
    public string IconURL;
}