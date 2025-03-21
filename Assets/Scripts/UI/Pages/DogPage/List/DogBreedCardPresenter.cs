using System;
using UnityEngine;
using Zenject;

public class DogBreedCardPresenter : IInitializable, IDisposable
{
    private readonly DogBreed _breedData;
    private readonly DogBreedCardView _cardView;
    private readonly IDogService _dogService;
    private readonly PopupPresenter _popupPresenter;

    public DogBreedCardPresenter(DogBreed breedData, DogBreedCardView cardView, IDogService dogService, PopupPresenter popupPresenter)
    {
        _breedData = breedData;
        _cardView = cardView;
        _dogService = dogService;
        _popupPresenter = popupPresenter;
    }

    public void Initialize()
    {
        _cardView.SetData(_breedData.Id, _breedData.Attributes.Name);
        _cardView.Click += CardView_OnClick;
    }

    public void Dispose()
    {
        _cardView.Click -= CardView_OnClick;
    }

    private void CardView_OnClick()
    {
        _cardView.SetLoading(true);
        _dogService.FetchBreedById(_breedData.Id, success =>
        {
            _popupPresenter.ShowPopup(success);
            _cardView.SetLoading(false);

        }, failure =>
        {
            Debug.LogError(failure);
            _cardView.SetLoading(false);
        });
    }
}
