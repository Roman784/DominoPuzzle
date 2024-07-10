using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Storage _storage;
    private SceneNamesConfig _sceneNames;
    private CurrentTheme _currentTheme;

    [Inject]
    private void Construct(Storage storage, SceneNamesConfig sceneNames, CurrentTheme currentTheme)
    {
        _storage = storage;
        _sceneNames = sceneNames;
        _currentTheme = currentTheme;

        LoadData();
    }

    private void LoadData()
    {
        _storage.Load(() =>
        {
            if (_storage.GameData == null)
                _storage.DefaultData();

            _currentTheme.Set(_storage.GameData.Theme.CurrentThemeId);
            // OpeningLevel.SetNumber();
            OpenGameplayScene();
        });
    }

    private void OpenGameplayScene()
    {
        SceneManager.LoadScene(_sceneNames.GameplayScene);
    }
}
