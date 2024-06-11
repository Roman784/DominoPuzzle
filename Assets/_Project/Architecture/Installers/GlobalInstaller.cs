using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private SceneNamesConfig _sceneNamesConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindOpeningLevelNumber();
    }

    private void BindConfigs()
    {
        Container.Bind<SceneNamesConfig>().FromInstance(_sceneNamesConfig).AsSingle();
    }

    private void BindOpeningLevelNumber()
    {
        Container.Bind<OpeningLevelNumber>().AsSingle();
    }
}
