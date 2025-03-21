using Newtonsoft.Json;
using System.Collections.Generic;

public class DogBreedResponseList
{
    [JsonProperty("data")]
    public List<DogBreed> Data { get; set; }
}
