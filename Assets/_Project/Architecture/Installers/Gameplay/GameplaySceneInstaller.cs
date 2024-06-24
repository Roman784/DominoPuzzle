using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private FieldCreator _fieldCreatorPrefab;

    [Space]

    [SerializeField] private FieldConfig _fieldConfig;
    [SerializeField] private FieldCreationConfig _fieldCreationConfig;
    [SerializeField] private FieldAnimationConfig _fieldAnimationConfig;
    [SerializeField] private TileConfig _tileConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindTileServices();
        BindHintGiver();
        BindFieldShuffling();
        BindFieldCreator();
    }

    private void BindConfigs()
    {
        Container.Bind<FieldConfig>().FromInstance(_fieldConfig).AsSingle();
        Container.Bind<FieldCreationConfig>().FromInstance(_fieldCreationConfig).AsSingle();
        Container.Bind<FieldAnimationConfig>().FromInstance(_fieldAnimationConfig).AsSingle();
        Container.Bind<TileConfig>().FromInstance(_tileConfig).AsSingle();
    }

    private void BindTileServices()
    {
        Container.Bind<ITileBehavior>().To<TileSwapBehavior>().AsSingle().NonLazy();
        Container.Bind<ITileMatcher>().To<MatchingTileMatcher>().AsSingle().NonLazy();
        Container.Bind<TileColorizer>().AsSingle().NonLazy();
    }

    private void BindHintGiver()
    {
        Container.Bind<HintGiver>().AsSingle().NonLazy();
    }

    private void BindFieldShuffling()
    {
        Container.Bind<IFieldShuffling>().To<FieldSwapShuffling>().AsSingle().NonLazy();
    }

    private void BindFieldCreator()
    {
        Container.Bind<FieldCreator>().FromComponentInNewPrefab(_fieldCreatorPrefab).AsSingle().NonLazy();
    }
}
