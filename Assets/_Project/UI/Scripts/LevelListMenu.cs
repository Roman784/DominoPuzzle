using UnityEngine;
using Zenject;

public class LevelListMenu : MonoBehaviour
{
    [SerializeField] private LevelButton _levelButtonPrefab;

    [Space]

    [SerializeField] private Transform _listContext;
    [SerializeField] private int _lastOpenedLevelNumber; // <-

    private DiContainer _diContainer;
    private FieldCreationConfig _fieldCreationConfig;

    [Inject]
    private void Construct(DiContainer diContainer, FieldCreationConfig fieldCreationConfig)
    {
        _diContainer = diContainer;
        _fieldCreationConfig = fieldCreationConfig;

        CreateLevelButtons();
    }

    private void CreateLevelButtons()
    {
        foreach(var fieldPrefab in _fieldCreationConfig.FieldPrefabsMap)
        {
            int levelNumber = fieldPrefab.Number;
            bool isLocked = levelNumber > _lastOpenedLevelNumber;

            CreateLevelButton(levelNumber, isLocked);
        }
    }

    private void CreateLevelButton(int levelNumber, bool isLocked)
    {
        LevelButton button = _diContainer.InstantiatePrefab(_levelButtonPrefab).GetComponent<LevelButton>();
        button.transform.SetParent(_listContext);
        button.transform.localScale = Vector3.one;

        button.Init(levelNumber, isLocked);
    }
}
