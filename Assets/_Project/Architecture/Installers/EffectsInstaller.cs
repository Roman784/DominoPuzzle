using UnityEngine;
using Zenject;

public class EffectsInstaller : MonoInstaller
{
    [SerializeField] private SceneTransitionEffect _sceneTransitionPrefab;

    public override void InstallBindings()
    {
        BindSceneTransition();
    }

    private void BindSceneTransition()
    {
        Container.Bind<SceneTransitionEffect>().FromComponentInNewPrefab(_sceneTransitionPrefab).AsSingle().NonLazy();
    }
}
