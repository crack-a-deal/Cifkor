using Newtonsoft.Json;
using UnityEngine;

public class WeatherParser
{
    public static WeatherResponse Parse(string json)
    {
        try
        {
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(json);

            if (weatherResponse?.Properties?.Periods == null || weatherResponse.Properties.Periods.Count == 0)
            {
                Debug.LogError("������: JSON �� �������� ������ � ������!");
                return null;
            }

            return weatherResponse;
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }
}
