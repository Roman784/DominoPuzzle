using System;
using System.Collections;
using UnityEngine;

public class ThemeSound
{
    private AudioSource _soundtrackPlayer;
    private AudioClip _soundtrack;

    public ThemeSound(AudioSource soundtrackPlayer, ThemeConfig config)
    {
        _soundtrackPlayer = soundtrackPlayer;
        _soundtrack = config.Soundtrack;

        _soundtrackPlayer.clip = _soundtrack;
    }

    public void PlaySoundtrack()
    {
        _soundtrackPlayer.Play();
        Coroutines.StartRoutine(ChangeSoundtrackVolume(0f, 1f, 2f, () => { }));
    }

    public void StopSoundtrack()
    {
        Coroutines.StartRoutine(ChangeSoundtrackVolume(1f, 0f, 2f, () => _soundtrackPlayer.Stop()));
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
}
