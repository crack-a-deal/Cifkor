using System.Collections.Generic;
using Zenject;

public class CardListPresenter
{
    private readonly CardFactory _cardFactory;
    private readonly CardListView _listView;

    private List<DogBreedCardPresenter> _activeCards = new List<DogBreedCardPresenter>();

    public CardListPresenter(CardFactory cardFactory, CardListView listView)
    {
        _cardFactory = cardFactory;
        _listView = listView;
    }

    public void UpdateList(List<DogBreed> breeds)
    {
        ClearList();

        foreach (DogBreed breed in breeds)
        {
            DogBreedCardView view = _listView.SpawnItem();
            //breed.Id = (_activeCards.Count + 1).ToString();

            DogBreedCardPresenter presenter = _cardFactory.Create(breed, view);
            presenter.Initialize();
            _activeCards.Add(presenter);
        }
    }

    public void ClearList()
    {
        foreach (DogBreedCardPresenter item in _activeCards)
        {
            item.Dispose();
        }
        _activeCards.Clear();
        _listView.ClearList();
    }
}

public class CardFactory : PlaceholderFactory<DogBreed, DogBreedCardView, DogBreedCardPresenter>
{
}

