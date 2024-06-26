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
        BindHint();
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
        Container.Bind<ITileBehavior>().To<TileSwapBehavior>().AsSingle();
        Container.Bind<ITileMatcher>().To<MatchingTileMatcher>().AsSingle();
        Container.Bind<TileColorizer>().AsSingle();
    }

    private void BindHint()
    {
        Container.Bind<IHint>().To<TileSwapHint>().AsSingle();
    }

    private void BindFieldShuffling()
    {
        Container.Bind<IFieldShuffling>().To<FieldSwapShuffling>().AsSingle();
    }

    private void BindFieldCreator()
    {
        Field prefab = _fieldCreationConfig.FieldPrefabsMap[0].Prefab;
        Container.Bind<Field>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}
