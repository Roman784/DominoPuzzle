using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Storage _storage;
    private SceneTransition _sceneTransition;
    private CurrentTheme _currentTheme;

    [Inject]
    private void Construct(Storage storage, SceneTransition sceneTransition, CurrentTheme currentTheme)
    {
        _storage = storage;
        _sceneTransition = sceneTransition;
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
            _sceneTransition.OpenGameplayScene();
        });
    }
}
