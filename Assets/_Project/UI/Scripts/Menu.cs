using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Menu : MonoBehaviour
{
    protected Storage Storage;
    protected SceneNamesConfig SceneNames;
    protected MenuSoundsConfig Sounds;
    protected SceneTransitionEffect SceneTransitionEffect;
    protected AudioPlayer AudioPlayer;

    [Inject]
    private void Construct(Storage storage, SceneNamesConfig sceneNames, MenuSoundsConfig sounds, SceneTransitionEffect sceneTransitionEffect, AudioPlayer audioPlayer)
    {
        Storage = storage;
        SceneNames = sceneNames;
        Sounds = sounds;
        SceneTransitionEffect = sceneTransitionEffect;
        AudioPlayer = audioPlayer;

        SceneTransitionEffect.Disappearance();
    }

    protected void OpenScene(string name)
    {
        StartCoroutine(OpenSceneRoutine(name));
    }

    private IEnumerator OpenSceneRoutine(string name)
    {
        yield return SceneTransitionEffect.Appearance();

        SceneManager.LoadScene(name);
    }

    protected void PlayButtonCLickSound()
    {
        AudioPlayer.Play(Sounds.ButtonClickSound);
    }
}
