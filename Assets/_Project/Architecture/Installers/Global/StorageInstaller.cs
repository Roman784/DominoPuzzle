using UnityEngine;
using Zenject;

public class StorageInstaller : MonoInstaller
{
    [SerializeField] private DefaultGameData _defaultGameData;

    public override void InstallBindings()
    {
        BindDefaultGameData();

        if (Application.platform == RuntimePlatform.WebGLPlayer)
            BindSDKStorage();
        else
           BindJsonStorage();
    }

    private void BindDefaultGameData()
    {
        Container.Bind<DefaultGameData>().FromInstance(_defaultGameData).AsSingle().NonLazy();
    }

    private void BindSDKStorage()
    {
        Container.Bind<Storage>().To<SDKStorage>().AsSingle();
    }

    private void BindJsonStorage()
    {
        Container.Bind<Storage>().To<JsonStorage>().AsSingle();
    }
}
