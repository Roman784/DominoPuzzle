using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private IHint _hint;
    private IFieldShuffling _shuffling;

    private int _hintCount;
    [SerializeField] private TMP_Text _hintCountView;

    [Inject]
    private void Constructor(Field field, IHint hint, IFieldShuffling shuffling)
    {
        _field = field;
        _hint = hint;
        _shuffling = shuffling;

        _hintCount = Storage.GameData.HintCount;
        UpdateView();
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
        if (_hintCount <= 0) return;

        PlayButtonCLickSound();

        _hint.Use();

        _hintCount -= 1;
        Storage.SetHintCount(_hintCount);
        UpdateView();
    }

    private void UpdateView()
    {
        _hintCountView.text = _hintCount.ToString();
    }
}
