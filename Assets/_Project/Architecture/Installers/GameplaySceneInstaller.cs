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
        BindTileBehavior();
        BindTileMatcher();
        BindFieldCreator();
    }

    private void BindConfigs()
    {
        Container.Bind<FieldConfig>().FromInstance(_fieldConfig).AsSingle();
        Container.Bind<FieldCreationConfig>().FromInstance(_fieldCreationConfig).AsSingle();
        Container.Bind<FieldAnimationConfig>().FromInstance(_fieldAnimationConfig).AsSingle();
        Container.Bind<TileConfig>().FromInstance(_tileConfig).AsSingle();
    }

    private void BindTileBehavior()
    {
        Container.Bind<ITileBehavior>().To<TileSwapBehavior>().AsSingle().NonLazy();
    }

    private void BindTileMatcher()
    {
        Container.Bind<ITileMatcher>().To<MatchingTileMatcher>().AsSingle().NonLazy();
    }

    private void BindFieldCreator()
    {
        Container.Bind<FieldCreator>().FromComponentInNewPrefab(_fieldCreatorPrefab).AsSingle().NonLazy();
    }
}
