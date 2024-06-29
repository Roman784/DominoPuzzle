using UnityEngine;
using Zenject;

public class AudioPlayer
{
    private AudioSourcer _sourcerPrefab;
    private float _volume;

    [Inject]
    private void Construct(AudioSourcer sourcerPrefab)
    {
        _sourcerPrefab = sourcerPrefab;
        _volume = 1; // <- θη αδ
    }

    public void Play(AudioClip clip)
    {
        AudioSourcer sourcer = GameObject.Instantiate(_sourcerPrefab);
        sourcer.PlayOneShot(clip, _volume);
    }
}
