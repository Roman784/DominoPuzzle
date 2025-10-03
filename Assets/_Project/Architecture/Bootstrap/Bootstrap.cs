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
                Debug.Log("Init sdk!");

                _storage.Load((bool res) =>
                {
                    if (!res)
                    {
                        _storage.DefaultData();
                        Debug.Log("Load storage!");
                    }
                    else
                    {
                        Debug.Log("Failed to load storage!");
                    }

                    OnDataLoaded();
                });
            }
            else
            {
                Debug.Log("Failed to init sdk!");
            }
        });
    }

    private void OnDataLoaded()
    {
        _audioPlayer.Init(_storage.GameData.Audio.Volume);
        _currentTheme.Set(_storage.GameData.Theme.CurrentThemeId);

        _SDK.ShowFullscreenAdv();
        _SDK.GameReady();

        OpeningLevel.SetNumber(_storage.GameData.Level.LastCompletedLevelNumber + 1);
        if (OpeningLevel.Number > _fieldCreationConfig.MaxNumber)
            _sceneTransition.OpenLevelListScenen();
        else
            _sceneTransition.OpenGameplayScene();
    }
}
