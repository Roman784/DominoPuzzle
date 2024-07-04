using System.Linq;
using UnityEngine;
using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private IHint _hint;
    private IFieldShuffling _shuffling;

    [Inject]
    private void Constructor(Field field, IHint hint, IFieldShuffling shuffling)
    {
        _field = field;
        _hint = hint;
        _shuffling = shuffling;
    }

    public void ChangeSoundVolume()
    {
        PlayButtonCLickSound();

        float newVolume = AudioPlayer.ChangeVolume();
        Storage.SetVolume(newVolume);
    }

    public void ShuffleField()
    {
        PlayButtonCLickSound();

        var tiles = _field.Tiles.ToList();
        _shuffling.Shuffle(tiles);
    }

    public void UseHint()
    {
        PlayButtonCLickSound();

        _hint.Use();
    }
}
