using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Storage _storage;
    private DefaultGameData _defaultGameData;
    private SceneNamesConfig _sceneNames;

    [Inject]
    private void Construct(Storage storage, DefaultGameData defaultGameData, SceneNamesConfig sceneNames)
    {
        _storage = storage;
        _defaultGameData = defaultGameData;
        _sceneNames = sceneNames;

        LoadData();
    }

    private void LoadData()
    {
        _storage.Load(() =>
        {
            if (_storage.GameData == null)
                _storage.DefaultData();

            OpenGameplayScene();
        });
    }

    private void OpenGameplayScene()
    {
        SceneManager.LoadScene(_sceneNames.GameplayScene);
    }
}
