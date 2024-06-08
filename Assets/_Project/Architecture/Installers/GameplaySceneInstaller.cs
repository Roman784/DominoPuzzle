using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Field _fieldPrefab;
    [SerializeField] private FieldSpawnConfig _fieldSpawnConfig;

    public override void InstallBindings()
    {
        BindTileSwapper();
        BindTileMatcher();
        BindField();
    }

    private void BindField()
    {
        Container.Bind<FieldSpawnConfig>().FromInstance(_fieldSpawnConfig);
        Container.Bind<Field>().FromComponentInNewPrefab(_fieldPrefab).AsSingle();
    }

    private void BindTileSwapper()
    {
        Container.BindInterfacesAndSelfTo<TileSwapBehavior>().AsSingle().NonLazy();
    }

    private void BindTileMatcher()
    {
        Container.BindInterfacesAndSelfTo<MatchingTileMatcher>().AsSingle().NonLazy();
    }
}
