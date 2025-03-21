using Newtonsoft.Json;

public class BreedAttributes
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}