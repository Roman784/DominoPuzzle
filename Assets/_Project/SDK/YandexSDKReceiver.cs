using UnityEngine;
using Zenject;

public class YandexSDKReceiver : MonoBehaviour
{
    private AudioPlayer _audioPlayer;

    public void Init(AudioPlayer audioPlayer)
    {
        _audioPlayer = audioPlayer;
    }

    public void StopGame()
    {
        _audioPlayer.StopPlayer();
        Time.timeScale = 0f;
        Debug.Log("Stop");
    }

    public void ContinueGame()
    {
        _audioPlayer.ResumePlayer();
        Time.timeScale = 1f;
        Debug.Log("Continue");
    }
}
