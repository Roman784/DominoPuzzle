using System.Collections;
using UnityEngine;

public class FieldSound
{
    private Field _field;
    private FieldSoundConfig _soundConfig;
    private FieldAnimationConfig _animationConfig;

    private AudioPlayer _audioPlayer;

    public FieldSound(Field field, FieldSoundConfig soundConfig, FieldAnimationConfig animationConfig, AudioPlayer audioPlayer)
    {
        _field = field;
        _soundConfig = soundConfig;
        _animationConfig = animationConfig;
        _audioPlayer = audioPlayer;
    }

    public void PlayTileAppearanceSound()
    {
        Coroutines.StartRoutine(PlayTileAppearanceSoundRoutine());
    }

    public void PlayTileDisappearanceSound()
    {
        Coroutines.StartRoutine(PlayTileDisappearanceSoundRoutine());
    }

    public void PlayFieldCompleteSound()
    {
        _audioPlayer.Play(_soundConfig.FieldCompleteSound);
    }

    private IEnumerator PlayTileAppearanceSoundRoutine()
    {
        int i = 0;
        foreach (Tile tile in _field.Tiles)
        {
            if (i % 2 == 1)
                tile.Sound.PlayFallSound();

            i++;
            yield return new WaitForSeconds(_animationConfig.TileAppearanceDelay);
        }
    }

    private IEnumerator PlayTileDisappearanceSoundRoutine()
    {
        int i = 0;
        foreach (Tile tile in _field.Tiles)
        {
            if (i % 2 == 1)
                tile.Sound.PlayLiftSound();

            i++;
            yield return new WaitForSeconds(_animationConfig.TileDisappearanceDelay);
        }
    }
}
