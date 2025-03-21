using Newtonsoft.Json;

public class DogBreedResponseSingle
{
    [JsonProperty("data")]
    public DogBreed Data { get; set; }
}
