using UnityEngine;
using Zenject;

public class ThemeInstaller : MonoInstaller
{
    [SerializeField] private ThemeCreationConfig _themeCreationConfig; 

    public override void InstallBindings()
    {
        BindConfigs();
        BindCreator();
    }

    private void BindConfigs()
    {
        Container.Bind<ThemeCreationConfig>().FromInstance(_themeCreationConfig).AsSingle();
    }

    private void BindCreator()
    {
        Container.Bind<ThemeCreator>().AsSingle().NonLazy();
    }
}
