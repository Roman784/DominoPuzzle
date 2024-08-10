using System;
using UnityEngine;

public abstract class SDK : MonoBehaviour
{
    [SerializeField] private string _tokenName;

    private bool _isGameStopped;
    private float _currentSoundVolume;

    public abstract void Init(Action<bool> callback = null);
    public abstract void SaveData(string data);
    public abstract void LoadData(Action<string> jsonCallback);
    public abstract void ShowRewardedVideo(Action<bool> callback = null);
    public abstract void ShowFullscreenAdv();
    public abstract Language GetLanguage();
    public abstract void GameReady();

    public void SetNameToToken()
    {
        gameObject.name = _tokenName;
    }

    public void StopGame()
    {
        if (_isGameStopped) return;
        _isGameStopped = true;

        _currentSoundVolume = AudioListener.volume;

        AudioListener.volume = 0;
        Time.timeScale = 0f;
        Debug.Log("Stop");
    }

    public void ContinueGame()
    {
        if (!_isGameStopped) return;
        _isGameStopped = false;

        AudioListener.volume = _currentSoundVolume;
        Time.timeScale = 1f;
        Debug.Log("Continue");
    }
}
