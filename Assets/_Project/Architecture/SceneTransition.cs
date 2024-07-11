using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneTransition : IInitializable, IDisposable
{
    private SceneNamesConfig _sceneNames;
    private SceneTransitionEffect _transitionEffect;

    [Inject]
    private void Construct(SceneNamesConfig sceneNames, SceneTransitionEffect transitionEffect)
    {
        _sceneNames = sceneNames;
        _transitionEffect = transitionEffect;
    }

    public void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Dispose()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OpenGameplayScene() => OpenScene(_sceneNames.GameplayScene);
    public void OpenLevelListScenen() => OpenScene(_sceneNames.LevelList);
    public void OpenThemeOptionsScenen() => OpenScene(_sceneNames.ThemeOptions);

    public void OpenScene(string name)
    {
        Coroutines.StartRoutine(OpenSceneRoutine(name));
    }

    private IEnumerator OpenSceneRoutine(string name)
    {
        yield return _transitionEffect.Appearance();
        SceneManager.LoadScene(name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _transitionEffect.Disappearance();
    }
}
