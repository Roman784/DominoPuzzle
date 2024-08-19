using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private IHint _hint;
    private IFieldShuffling _shuffling;

    [SerializeField] private HintRecoveryMenu _hintRecoveryMenu;

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

        _hintRecoveryMenu.OnRecovered.AddListener(RecoverHints);
    }

    public void ChangeSoundVolume()
    {
        PlayButtonCLickSound();

        float newVolume = AudioPlayer.ChangeVolume();
        Storage.SetVolume(newVolume);
    }

    public void ShuffleField()
    {
        SDK.ShowFullscreenAdv();

        PlayButtonCLickSound();

        var tiles = _field.Tiles.ToList();
        _shuffling.Shuffle(tiles);
    }

    public void UseHint()
    {
        if (_hintCount <= 0)
        {
            _hintRecoveryMenu.OpenPanel();
            return;
        }

        PlayButtonCLickSound();

        _hint.Use();
        SetHintCount(_hintCount - 1);
    }

    private void RecoverHints()
    {
        SetHintCount(3);
    }

    private void SetHintCount(int count)
    {
        _hintCount = count;
        Storage.SetHintCount(_hintCount);
        UpdateView();
    }

    private void UpdateView()
    {
        _hintCountView.text = _hintCount.ToString();
    }
}
