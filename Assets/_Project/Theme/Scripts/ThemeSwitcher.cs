using UnityEngine;

public class ThemeSwitcher : MonoBehaviour
{
    [SerializeField] private Theme[] _themes;
    private int _themeIndex = 0;

    private void Start()
    {
        _themes[_themeIndex].ActivateFully();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            Switch(-1);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            Switch(1);
    }

    public void SelectTheme()
    {

    }

    public void Switch(int step)
    {
        int previousIndex = _themeIndex;
        _themeIndex += step;

        ClampThemeIndex();

        _themes[previousIndex].Disappearance();
        _themes[_themeIndex].Appearance();
    }

    private void ClampThemeIndex()
    {
        if (_themeIndex >= _themes.Length) _themeIndex = 0;
        if (_themeIndex < 0) _themeIndex = _themes.Length - 1;
    }
}
