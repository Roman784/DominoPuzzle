using UnityEngine;
using Zenject;

public class StorageInstaller : MonoInstaller
{
    [SerializeField] private DefaultGameData _defaultGameData;

    public override void InstallBindings()
    {
        BindDefaultGameData();
        BindStorage();
    }

    private void BindDefaultGameData()
    {
        Container.Bind<DefaultGameData>().FromInstance(_defaultGameData).AsSingle().NonLazy();
    }

    private void BindStorage()
    {
        Container.Bind<Storage>().To<JsonStorage>().AsSingle();
    }
}
