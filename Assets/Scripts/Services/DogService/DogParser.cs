using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class DogParser
{
    public static List<DogBreed> ParseToList(string json)
    {
        try
        {
            DogBreedResponseList breedResponse = JsonConvert.DeserializeObject<DogBreedResponseList>(json);

            if (breedResponse?.Data == null || breedResponse.Data.Count == 0)
            {
                Debug.LogError("������: ������ �� �������� ������ � �������!");
                return null;
            }

            return breedResponse.Data;
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }

    public static DogBreed Parse(string json)
    {
        try
        {
            DogBreedResponseSingle breedResponse = JsonConvert.DeserializeObject<DogBreedResponseSingle>(json);

            if (breedResponse.Data == null)
            {
                Debug.LogError("������: ������ �� �������� ������ � ������!");
                return null;
            }

            return breedResponse.Data;
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }
}
