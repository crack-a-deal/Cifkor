using Newtonsoft.Json;

public class WeatherResponse
{
    [JsonProperty("properties")]
    public WeatherProperties Properties { get; set; }
}
