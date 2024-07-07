using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private Storage _storage;
    private SceneNamesConfig _sceneNames;

    [Inject]
    private void Construct(Storage storage, SceneNamesConfig sceneNames)
    {
        _storage = storage;
        _sceneNames = sceneNames;

        LoadData();
    }

    private void LoadData()
    {
        _storage.Load(() =>
        {
            if (_storage.GameData == null)
                _storage.DefaultData();

            // OpeningLevel.SetNumber();
            OpenGameplayScene();
        });
    }

    private void OpenGameplayScene()
    {
        SceneManager.LoadScene(_sceneNames.GameplayScene);
    }
}
