using UnityEngine;
using Zenject;

public class SDKInstaller : MonoInstaller
{
    [SerializeField] private YandexSDK _yandexSDK;

    public override void InstallBindings()
    {
        Container.Bind<SDK>().FromComponentInNewPrefab(_yandexSDK).AsSingle();
    }
}
