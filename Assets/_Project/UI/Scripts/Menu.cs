using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
    protected SceneNamesConfig SceneNames;
    protected MenuSoundsConfig Sounds;
    protected SceneTransitionEffect SceneTransitionEffect;
    protected AudioPlayer AudioPlayer;

    private Coroutine _sceneTransitionRoutine;

    [Inject]
    private void Construct(SceneNamesConfig sceneNames, MenuSoundsConfig sounds, SceneTransitionEffect sceneTransitionEffect, AudioPlayer audioPlayer)
    {
        SceneNames = sceneNames;
        Sounds = sounds;
        SceneTransitionEffect = sceneTransitionEffect;
        AudioPlayer = audioPlayer;
    }

    protected void Start()
    {
        SceneTransitionEffect.Disappearance();
    }

    protected void OpenScene(string name)
    {
        _sceneTransitionRoutine = SceneTransitionEffect.Appearance();
        StartCoroutine(OpenSceneRoutine(name));
    }

    private IEnumerator OpenSceneRoutine(string name)
    {
        yield return _sceneTransitionRoutine;

        SceneManager.LoadScene(name);
    }

    protected void PlayButtonCLickSound()
    {
        AudioPlayer.Play(Sounds.ButtonClickSound);
    }
}
