using System.Collections.Generic;

public class ThemeOptions
{
    private List<Theme> _themes = new List<Theme>();
    private int _viewedThemeIndex;

    private Theme _viewedTheme => _themes[_viewedThemeIndex];

    private CurrentTheme _currentTheme;
    private ThemeCreator _creator;
    private ThemeCreationConfig _creationConfig;

    public ThemeOptions(CurrentTheme currentTheme, ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        _currentTheme = currentTheme;
        _creator = creator;
        _creationConfig = creationConfig;

        _currentTheme.Theme.Deactivate();

        CreateOptions();
        SetViewedThemeIndex();

        _viewedTheme.Activate();
    }

    public void Select()
    {
        // id заменить на сохранение в бд.
        _currentTheme.SetTheme(_viewedTheme.Id);
        _currentTheme.Theme.ActivateBackground();
    }

    public void Switch(int step)
    {
        _viewedTheme.Animation.Disappearance();

        _viewedThemeIndex += step;
        ClampViewedThemeIndex();

        _viewedTheme.Activate();
        _viewedTheme.Animation.Appearance();
    }

    private void CreateOptions()
    {
        foreach (var item in _creationConfig.ThemePrefabsMap)
        {
            int id = item.Id;

            Theme theme = _creator.Create(id);

            theme.Init(id);
            theme.Deactivate();

            _themes.Add(theme);
        }
    }

    // Sets from the database.
    private void SetViewedThemeIndex()
    {
        for (int i = 0; i < _themes.Count; i++) // <-----------------------------------------------------------
        {
            if (_themes[i].Id == 0) // <- id из бд
            {
                _viewedThemeIndex = i;
                break;
            }
        }
    }

    private void ClampViewedThemeIndex()
    {
        if (_viewedThemeIndex >= _themes.Count) _viewedThemeIndex = 0;
        if (_viewedThemeIndex < 0) _viewedThemeIndex = _themes.Count - 1;
    }
}
