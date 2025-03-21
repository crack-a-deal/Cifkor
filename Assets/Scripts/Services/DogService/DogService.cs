using System;
using System.Collections.Generic;

public class DogService : IDogService
{
    private const string API_URL = "https://dogapi.dog/api/v2/breeds";

    private readonly RequestManager _requestManager;

    public DogService(RequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public void FetchAllBreeds(Action<List<DogBreed>> successCallback, Action<string> failureCallback)
    {
        ServerRequest<string> breedsRequest = new ServerRequest<string>(API_URL, response =>
        {
            List<DogBreed> breeddds = DogParser.ParseToList(response);
            successCallback?.Invoke(breeddds);

        }, errorText =>
        {
            failureCallback?.Invoke("Ошибка получения списка пород: " + errorText);
        }
        );

        _requestManager.EnqueueRequest(breedsRequest);
    }

    public void FetchBreedById(string id, Action<DogBreed> successCallback, Action<string> failureCallback)
    {
        ServerRequest<string> breedRequest = new ServerRequest<string>(API_URL + $"/{id}", response =>
        {
            DogBreed apiResponse = DogParser.Parse(response);
            successCallback?.Invoke(apiResponse);
        }, errorText =>
        {
            failureCallback?.Invoke("Ошибка получения информации о породе: " + errorText);
        }
        );

        _requestManager.EnqueueRequest(breedRequest);
    }
}
