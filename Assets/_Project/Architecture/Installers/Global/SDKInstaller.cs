using Zenject;

public class SDKInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISDK>().To<YandexSDK>().AsSingle().NonLazy();
    }
}
