using UnityEngine;
using Zenject;

public class ThemeInstaller : MonoInstaller
{
    [SerializeField] private ThemeCreationConfig _themeCreationConfig;

    public override void InstallBindings()
    {
        BindConfigs();

        BindThemeCreator();
        BindCurrentTheme();
    }

    private void BindConfigs()
    {
        Container.Bind<ThemeCreationConfig>().FromInstance(_themeCreationConfig).AsSingle();
    }

    private void BindThemeCreator()
    {
        Container.Bind<ThemeCreator>().AsSingle().NonLazy();
    }

    private void BindCurrentTheme()
    {
        Container.Bind<CurrentTheme>().AsSingle().NonLazy();
    }
}
