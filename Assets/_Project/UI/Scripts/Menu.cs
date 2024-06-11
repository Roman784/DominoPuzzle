using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
    private SceneTransitionEffect _sceneTransitionEffect;

    [Inject]
    private void Construct(SceneTransitionEffect sceneTransitionEffect)
    {
        _sceneTransitionEffect = sceneTransitionEffect;
    }

    private void Start()
    {
        _sceneTransitionEffect.Disappearance();
    }

    protected void OpenScene(string name)
    {
        StartCoroutine(OpenSceneRoutine(name));
    }

    private IEnumerator OpenSceneRoutine(string name)
    {
        yield return _sceneTransitionEffect.Appearance();

        SceneManager.LoadScene(name);
    }
}
