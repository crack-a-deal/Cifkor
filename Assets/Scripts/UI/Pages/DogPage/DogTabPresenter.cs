using System.Threading;
using UnityEngine;

public class DogTabPresenter : BaseTabPresenter
{
    private readonly IDogService _dogService;
    private readonly DogTabView _view;
    private readonly CardListPresenter _cardListPresenter;
    private CancellationTokenSource _cts = new CancellationTokenSource();

    public DogTabPresenter(IDogService dogService, ITabView tabView, CardListPresenter cardListPresenter) : base(tabView)
    {
        _dogService = dogService;
        _cardListPresenter = cardListPresenter;
        _view = (DogTabView)tabView;
    }

    protected override void TabView_OnTabOpened()
    {
        Debug.Log("Dog page opened");

        LoadDogBreeds();
    }

    protected override void TabView_OnTabClosed()
    {
        Debug.Log("Dog page closed");

        _cardListPresenter.ClearList();
    }

    private void LoadDogBreeds()
    {
        _dogService.FetchAllBreeds(breeds =>
        {
            _cardListPresenter.UpdateList(breeds);
        },
        x => { Debug.LogError(x); });
    }
}
