using UnityEngine;

public class TileSound
{
    [SerializeField] private AudioClip _fallSound;

    private AudioPlayer _audioPlayer;

    public TileSound(AudioPlayer audioPlayer, TileConfig config)
    {
        _audioPlayer = audioPlayer;

        _fallSound = config.FallSound;
    }

    public void PlayFallSound()
    {
        _audioPlayer.Play(_fallSound);
    }
}
