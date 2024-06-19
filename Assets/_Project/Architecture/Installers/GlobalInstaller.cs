using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private SceneTransitionEffect _sceneTransitionEffect;

    [Space]

    [SerializeField] private SceneNamesConfig _sceneNamesConfig;

    public override void InstallBindings()
    {
        BindConfigs();

        BindOpeningLevelNumber();
        BindSceneTransitionEffect();
    }

    private void BindConfigs()
    {
        Container.Bind<SceneNamesConfig>().FromInstance(_sceneNamesConfig).AsSingle();
    }

    private void BindOpeningLevelNumber()
    {
        Container.Bind<OpeningLevelNumber>().AsSingle();
    }

    private void BindSceneTransitionEffect()
    {
        Container.Bind<SceneTransitionEffect>().FromComponentInNewPrefab(_sceneTransitionEffect).AsSingle().NonLazy();
    }
}
