using Zenject;

public class LocalizationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Localization>().AsSingle();
    }
}
