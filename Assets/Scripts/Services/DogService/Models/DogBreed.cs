using Newtonsoft.Json;

public class DogBreed
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("attributes")]
    public BreedAttributes Attributes { get; set; }
}
