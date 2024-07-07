using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Space]

    private int _number;
    [SerializeField] private TMP_Text _numberView;

    private bool _isLocked;
    [SerializeField] private GameObject _lockView;

    private LevelListMenu _menu;

    private void Awake()
    {
        _button.onClick.AddListener(OpenLevel);
    }

    public void Init(int number, bool isLocked, LevelListMenu menu)
    {
        _number = number;
        _isLocked = isLocked;
        _menu = menu;

        UpdateView();
    }

    private void OpenLevel()
    {
        if (_isLocked) return;

        _menu.OpenLevel(_number);
    }

    private void UpdateView()
    {
        _numberView.text = _number.ToString();
        _lockView.SetActive(_isLocked);
    }
}