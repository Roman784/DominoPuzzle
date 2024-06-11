using UnityEngine;

public class LevelListMenu : MonoBehaviour
{
    [SerializeField] private LevelButton _levelButtonPrefab;

    [Space]

    [SerializeField] private Transform _listContext;
    [SerializeField] private int _lastOpenedLevelNumber; // <-

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
        LevelButton button = Instantiate(_levelButtonPrefab, transform.position, Quaternion.identity, _listContext);
        button.Init(levelNumber, isLocked);
    }
}
