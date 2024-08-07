using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private SDK _SDK;
    private Localization _localization;
    private Storage _storage;
    private SceneTransition _sceneTransition;
    private CurrentTheme _currentTheme;
    private FieldCreationConfig _fieldCreationConfig;
    private AudioPlayer _audioPlayer;

    [Inject]
    private void Construct(SDK SDK, Storage storage, Localization localization, SceneTransition sceneTransition, CurrentTheme currentTheme, FieldCreationConfig fieldCreationConfig, AudioPlayer audioPlayer)
    {
        _SDK = SDK;
        _localization = localization;
        _storage = storage;
        _sceneTransition = sceneTransition;
        _currentTheme = currentTheme;
        _fieldCreationConfig = fieldCreationConfig;
        _audioPlayer = audioPlayer;

        Init();
    }

    private void Init()
    {
        _SDK.Init((bool res) => 
        {
            if (res)
            {
                _localization.Init();
                _storage.Load(() =>
                {
                    OnDataLoaded();
                });
            }
        });
    }

    private void OnDataLoaded()
    {
        if (_storage.GameData == null)
            _storage.DefaultData();

        _audioPlayer.Init(_storage.GameData.Audio.Volume);
        _currentTheme.Set(_storage.GameData.Theme.CurrentThemeId);

        OpeningLevel.SetNumber(_storage.GameData.Level.LastCompletedLevelNumber + 1);
        if (OpeningLevel.Number > _fieldCreationConfig.MaxNumber)
            _sceneTransition.OpenLevelListScenen();
        else
            _sceneTransition.OpenGameplayScene();
    }
}
