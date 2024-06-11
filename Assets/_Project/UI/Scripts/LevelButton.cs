using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : Menu
{
    [SerializeField] private Button _button;

    [Space]

    private int _number;
    [SerializeField] private TMP_Text _numberView;

    private bool _isLocked;
    [SerializeField] private GameObject _lockView;

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

        OpenScene("GameplayScene");
    }

    private void UpdateView()
    {
        _numberView.text = _number.ToString();
        _lockView.SetActive(_isLocked);
    }
}