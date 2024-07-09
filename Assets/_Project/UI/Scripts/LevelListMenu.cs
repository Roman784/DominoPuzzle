using UnityEngine;
using Zenject;

public class LevelListMenu : SceneMenu
{
    [SerializeField] private LevelButton _levelButtonPrefab;

    [Space]

    [SerializeField] private Transform _listContext;

    private int _lastCompletedLevelNumber;

    private DiContainer _diContainer;
    private FieldCreationConfig _fieldCreationConfig;

    [Inject]
    private void Construct(DiContainer diContainer, FieldCreationConfig fieldCreationConfig)
    {
        _diContainer = diContainer;
        _fieldCreationConfig = fieldCreationConfig;

        _lastCompletedLevelNumber = Storage.GameData.Level.LastCompletedLevelNumber;

        CreateLevelButtons();
    }

    public void OpenLevel(int number)
    {
        PlayButtonCLickSound();

        OpeningLevel.SetNumber(number);
        OpenGameplayScene();
    }

    private void CreateLevelButtons()
    {
        foreach(var fieldPrefab in _fieldCreationConfig.FieldPrefabsMap)
        {
            int levelNumber = fieldPrefab.Number;
            bool isLocked = levelNumber > _lastCompletedLevelNumber + 1;

            CreateLevelButton(levelNumber, isLocked);
        }
    }

    private void CreateLevelButton(int levelNumber, bool isLocked)
    {
        LevelButton button = _diContainer.InstantiatePrefab(_levelButtonPrefab).GetComponent<LevelButton>();
        button.transform.SetParent(_listContext);
        button.transform.localScale = Vector3.one;

        button.Init(levelNumber, isLocked, this);
    }
}
