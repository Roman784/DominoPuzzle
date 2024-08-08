using System;
using UnityEngine;
using Zenject;

public abstract class SDK : MonoBehaviour
{
    [SerializeField] private string _tokenName;

    private AudioPlayer _audioPlayer;

    [Inject]
    private void Construct(AudioPlayer audioPlayer)
    {
        _audioPlayer = audioPlayer;

        transform.SetParent(null);
        gameObject.name = _tokenName;
    }

    public abstract void Init(Action<bool> callback = null);
    public abstract void SaveData(string data);
    public abstract void LoadData(Action<string> jsonCallback);
    public abstract void ShowRewardedVideo(Action<bool> callback = null);
    public abstract void ShowFullscreenAdv();
    public abstract Language GetLanguage();

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
