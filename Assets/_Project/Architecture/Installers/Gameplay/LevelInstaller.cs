using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLevelCompletionHandler();
    }

    private void BindLevelCompletionHandler()
    {
        Container.BindInterfacesAndSelfTo<LevelCompletionHandler>().AsSingle().NonLazy();
    }
}
