using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ThemeSwitcher : SceneMenu
{
    private List<Theme> _themes = new List<Theme>();
    private int _themeIndex = 0;

    private Theme _current => _themes[_themeIndex];

    private CurrentTheme _currentTheme;

    [Inject]
    private void Construct(ThemeCreator creator, ThemeCreationConfig creationConfig, CurrentTheme currentTheme)
    {
        _currentTheme = currentTheme;

        CreateThemes(creator, creationConfig);
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
        CurrentTheme.id = _current.Id; // <- ����� �������� �� ���������� � ��.
        _currentTheme.InvokeThemeChangedEvent(_current);
        OpenGameplayScene();
    }

    public void Switch(int step)
    {
        int previousIndex = _themeIndex;
        _themeIndex += step;

        ClampThemeIndex();

        _current.Activate();
        _current.Animation.Appearance();
        _themes[previousIndex].Animation.Disappearance();
    }

    private void CreateThemes(ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        _currentTheme.Destroy();

        foreach (var item in creationConfig.ThemePrefabsMap)
        {
            int id = item.Id;

            Theme theme = creator.Create(id);

            theme.Init(id);
            theme.Deactivate();

            _themes.Add(theme);
        }

        for (int i = 0; i < _themes.Count; i++) // <-----------------------------------------------------------
        {
            if (_themes[i].Id == CurrentTheme.id)
            {
                _themeIndex = i;
                break;
            }
        }

        _themes[_themeIndex].Activate();
    }

    private void ClampThemeIndex()
    {
        if (_themeIndex >= _themes.Count) _themeIndex = 0;
        if (_themeIndex < 0) _themeIndex = _themes.Count - 1;
    }
}
