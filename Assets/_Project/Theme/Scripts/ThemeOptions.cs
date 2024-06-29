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

        _currentTheme.Theme.Activate();
        CreateOptions();
    }

    public void Select()
    {
        // id заменить на сохранение в бд.
        _currentTheme.SetExisting(_viewedTheme);
        _currentTheme.Theme.ActivateBackground();
        _currentTheme.Theme.DeactivateTitle();
    }

    public void Switch(int step)
    {
        _viewedTheme.Animation.Disappearance();
        _viewedTheme.Sound.StopSoundtrack();

        _viewedThemeIndex += step;
        ClampViewedThemeIndex();

        _viewedTheme.Activate();
        _viewedTheme.Animation.Appearance();
        _viewedTheme.Sound.PlaySoundtrack();
    }

    private void CreateOptions()
    {
        int i = 0;
        foreach (var item in _creationConfig.ThemePrefabsMap)
        {
            int id = item.Id;

            if (id == _currentTheme.Theme.Id)
            {
                _themes.Add(_currentTheme.Theme);
                _viewedThemeIndex = i;
                continue;
            }

            Theme theme = _creator.Create(id);

            theme.Init(id);
            theme.Deactivate();

            _themes.Add(theme);

            i++;
        }
    }

    private void ClampViewedThemeIndex()
    {
        if (_viewedThemeIndex >= _themes.Count) _viewedThemeIndex = 0;
        if (_viewedThemeIndex < 0) _viewedThemeIndex = _themes.Count - 1;
    }
}
