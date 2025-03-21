using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private WeatherTabView weatherPageView;

    [SerializeField] private DogTabView dogPageView;
    [SerializeField] private CardListView cardListView;

    [SerializeField] private PopupView popupView;
    [SerializeField] private TabGroupView tabGroupView;

    public override void InstallBindings()
    {
        // Weather Tab
        Container
            .BindInterfacesAndSelfTo<WeatherTabPresenter>()
            .AsSingle()
            .WithArguments(weatherPageView)
            .NonLazy();


        // Dog Breeds Tab
        Container
            .BindFactory<DogBreed, DogBreedCardView, DogBreedCardPresenter, CardFactory>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<CardListPresenter>()
            .AsSingle()
            .WithArguments(cardListView)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<DogTabPresenter>()
            .AsSingle()
            .WithArguments(dogPageView)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<TabGroupPresenter>()
            .AsSingle()
            .WithArguments(tabGroupView)
            .NonLazy();

        Container
            .Bind<PopupPresenter>()
            .AsSingle()
            .WithArguments(popupView)
            .NonLazy();
    }
}
