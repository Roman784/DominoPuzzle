using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Storage _storage;
    private SceneTransition _sceneTransition;
    private CurrentTheme _currentTheme;
    private FieldCreationConfig _fieldCreationConfig;

    [Inject]
    private void Construct(Storage storage, SceneTransition sceneTransition, CurrentTheme currentTheme, FieldCreationConfig fieldCreationConfig)
    {
        _storage = storage;
        _sceneTransition = sceneTransition;
        _currentTheme = currentTheme;
        _fieldCreationConfig = fieldCreationConfig;

        LoadData();
    }

    private void LoadData()
    {
        _storage.Load(() =>
        {
            if (_storage.GameData == null)
                _storage.DefaultData();

            _currentTheme.Set(_storage.GameData.Theme.CurrentThemeId);

            OpeningLevel.SetNumber(_storage.GameData.Level.LastCompletedLevelNumber + 1);
            if (OpeningLevel.Number > _fieldCreationConfig.MaxNumber)
                _sceneTransition.OpenLevelListScenen();
            else
                _sceneTransition.OpenGameplayScene();
        });
    }
}
