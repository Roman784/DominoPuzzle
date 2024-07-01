using UnityEngine;

public class TileSound
{
    private TileConfig _config;
    private AudioPlayer _audioPlayer;

    public TileSound(TileConfig config, AudioPlayer audioPlayer)
    {
        _config = config;
        _audioPlayer = audioPlayer;
    }

    public void PlayFallSound()
    {
        _audioPlayer.Play(_config.FallSound);
    }

    public void PlayLiftSound()
    {
        _audioPlayer.Play(_config.LiftSound);
    }
}
