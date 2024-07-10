using System;
using System.Collections;
using UnityEngine;

public class ThemeSound
{
    private AudioSource _soundtrackPlayer;
    private AudioClip _soundtrack;

    private Coroutine _currentRoutine;

    public ThemeSound(AudioSource soundtrackPlayer, ThemeConfig config)
    {
        _soundtrackPlayer = soundtrackPlayer;
        _soundtrack = config.Soundtrack;

        _soundtrackPlayer.clip = _soundtrack;
    }

    public void PlaySoundtrack()
    {
        _soundtrackPlayer.Play();

        StopCurrentRoutine();
        _currentRoutine = Coroutines.StartRoutine(ChangeSoundtrackVolume(0f, 1f, 2f, () => { }));
    }

    public void StopSoundtrack()
    {
        StopCurrentRoutine();
        _currentRoutine = Coroutines.StartRoutine(ChangeSoundtrackVolume(1f, 0f, 2f, 
            () => _soundtrackPlayer.Stop()));
    }

    private IEnumerator ChangeSoundtrackVolume(float from, float to, float duration, Action callback)
    {
        _soundtrackPlayer.volume = from;

        for (float time = 0f; time < duration; time += Time.deltaTime)
        {
            float volume = Mathf.Lerp(from, to, time / duration);
            _soundtrackPlayer.volume = volume;

            yield return null;
        }

        _soundtrackPlayer.volume = to;

        callback?.Invoke();
    }

    private void StopCurrentRoutine()
    {
        if (_currentRoutine != null)
            Coroutines.StopRoutine(_currentRoutine);
    }
}
