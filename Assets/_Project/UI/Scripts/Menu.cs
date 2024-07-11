using UnityEngine;
using Zenject;

public class Menu : MonoBehaviour
{
    protected Storage Storage;
    protected SceneTransition SceneTransition;
    protected MenuSoundsConfig Sounds;
    protected AudioPlayer AudioPlayer;

    [Inject]
    private void Construct(Storage storage, SceneTransition sceneTransition, MenuSoundsConfig sounds, AudioPlayer audioPlayer)
    {
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
