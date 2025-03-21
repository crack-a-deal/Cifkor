using Newtonsoft.Json;
using System.Collections.Generic;

public class WeatherProperties
{
    [JsonProperty("periods")]
    public List<ForecastPeriod> Periods { get; set; }
}
