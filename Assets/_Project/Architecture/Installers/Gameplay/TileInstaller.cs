using UnityEngine;
using Zenject;

public class TileInstaller : MonoInstaller
{
    [SerializeField] private TileConfig _tileConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindBehavior();
        BindMatcher();
        BindColorizer();
    }

    private void BindConfigs()
    {
        Container.Bind<TileConfig>().FromInstance(_tileConfig).AsSingle();
    }

    private void BindBehavior()
    {
        Container.Bind<ITileBehavior>().To<TileSwapBehavior>().AsSingle();
    }

    private void BindMatcher()
    {
        Container.Bind<ITileMatcher>().To<MatchingTileMatcher>().AsSingle();
    }

    private void BindColorizer()
    {
        Container.Bind<TileColorizer>().AsSingle();
    }
}
