using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AudioPlayer
{
    public UnityEvent<float> OnVolumeChanged = new UnityEvent<float>();

    private AudioSourcer _sourcerPrefab;
    private float _volume;

    [Inject]
    private void Construct(AudioSourcer sourcerPrefab)
    {
        _sourcerPrefab = sourcerPrefab;
    }

    public void Init(float volume)
    {
        _volume = volume;
        UpdateAudioListener(_volume);

        OnVolumeChanged.AddListener(UpdateAudioListener);
    }

    public float Volume => _volume;

    public void Play(AudioClip clip)
    {
        AudioSourcer sourcer = GameObject.Instantiate(_sourcerPrefab);
        sourcer.PlayOneShot(clip, _volume);
    }

    public float ChangeVolume()
    {
        _volume = _volume > 0f ? 0f : 1f;
        OnVolumeChanged?.Invoke(_volume);

        return _volume;
    }

    private void UpdateAudioListener(float volume)
    {
        AudioListener.volume = volume;
    }
}
