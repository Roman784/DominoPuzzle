using UnityEngine;
using Zenject;

public class SDKInstaller : MonoInstaller
{
    [SerializeField] private YandexSDK _yandexSDK;

    public override void InstallBindings()
    {
        YandexSDK SDK = Instantiate(_yandexSDK, Vector2.zero, Quaternion.identity, null);
        Container.Bind<SDK>().FromInstance(SDK).AsSingle().NonLazy();

        DontDestroyOnLoad(SDK.gameObject);
        SDK.SetNameToToken();
    }
}
