using UnityEngine;
using Zenject;

public class Menu : MonoBehaviour
{
    protected SDK SDK;
    protected Storage Storage;
    protected SceneTransition SceneTransition;
    protected MenuSoundsConfig Sounds;
    protected AudioPlayer AudioPlayer;

    [Inject]
    private void Construct(SDK Sdk, Storage storage, SceneTransition sceneTransition, MenuSoundsConfig sounds, AudioPlayer audioPlayer)
    {
        SDK = Sdk;
        Storage = storage;
        SceneTransition = sceneTransition;
        Sounds = sounds;
        AudioPlayer = audioPlayer;
    }

    protected void PlayButtonCLickSound()
    {
        AudioPlayer.Play(Sounds.ButtonClickSound);
    }
}
