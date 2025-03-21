using System;
using System.Collections.Generic;

public interface IDogService
{
    void FetchAllBreeds(Action<List<DogBreed>> successCallback, Action<string> failureCallback);
    void FetchBreedById(string id, Action<DogBreed> successCallback, Action<string> failureCallback);
}
