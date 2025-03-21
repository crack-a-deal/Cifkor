using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<RequestManager>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<IWeatherService>()
            .To<WeatherService>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<IDogService>()
            .To<DogService>()
            .AsSingle()
            .NonLazy();
    }
}
