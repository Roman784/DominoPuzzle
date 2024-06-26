using Zenject;

public class HintInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindHint();
    }

    private void BindHint()
    {
        Container.Bind<IHint>().To<TileSwapHint>().AsSingle();
    }
}