using UnityEngine;
using Zenject;

public class LevelListMenu : MonoBehaviour
{
    [SerializeField] private LevelButton _levelButtonPrefab;

    [Space]

    [SerializeField] private Transform _listContext;
    [SerializeField] private int _lastOpenedLevelNumber; // <-

    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    private void Start()
    {
        for (int i = 1; i <= 99; i++)
        {
            bool isLocked = i > _lastOpenedLevelNumber;
            CreateLevelButton(i, isLocked);
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
