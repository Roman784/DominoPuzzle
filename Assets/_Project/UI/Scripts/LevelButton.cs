using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelButton : Menu
{
    [SerializeField] private Button _button;

    [Space]

    private int _number;
    [SerializeField] private TMP_Text _numberView;

    private bool _isLocked;
    [SerializeField] private GameObject _lockView;

    private SceneNamesConfig _sceneNames;
    private OpeningLevelNumber _openingLevelNumber;

    [Inject]
    private void Construct(SceneNamesConfig sceneNames, OpeningLevelNumber openingLevelNumber)
    {
        _sceneNames = sceneNames;
        _openingLevelNumber = openingLevelNumber;
    }

    private void Awake()
    {
        _button.onClick.AddListener(OpenLevel);
    }

    public void Init(int number, bool isLocked)
    {
        _number = number;
        _isLocked = isLocked;

        UpdateView();
    }

    private void OpenLevel()
    {
        if (_isLocked) return;

        _openingLevelNumber.SetNumber(_number);
        OpenScene(_sceneNames.GameplayScene);
    }

    private void UpdateView()
    {
        _numberView.text = _number.ToString();
        _lockView.SetActive(_isLocked);
    }
}