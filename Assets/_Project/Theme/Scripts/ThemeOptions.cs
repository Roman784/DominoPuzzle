using System.Collections.Generic;
using UnityEngine;

public class ThemeOptions
{
    private List<Theme> _themes = new List<Theme>();
    private int ViewedThemeIndex;

    private Storage _storage;
    private CurrentTheme _currentTheme;
    private ThemeCreator _creator;
    private ThemeCreationConfig _creationConfig;

    public ThemeOptions(Storage storage, CurrentTheme currentTheme, ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        _storage = storage;
        _currentTheme = currentTheme;
        _creator = creator;
        _creationConfig = creationConfig;

        _currentTheme.Theme.Activate();
        CreateOptions();
    }

    public Theme ViewedTheme => _themes[ViewedThemeIndex];

    public void Select()
    {
        _currentTheme.SetExisting(ViewedTheme);
        _storage.SetCurrentThemeId(ViewedTheme.Id);

        DestroyUnviewedThemes();
    }

    public void Switch(int step)
    {
        ViewedTheme.Animation.Disappearance();
        ViewedTheme.Sound.StopSoundtrack();

        ViewedThemeIndex += step;
        ClampViewedThemeIndex();

        ViewedTheme.Activate();
        ViewedTheme.Animation.Appearance();
        ViewedTheme.Sound.PlaySoundtrack();
    }

    public void UnlockViewedTheme()
    {
        ViewedTheme.Unlock();
        _storage.UnlockTheme(ViewedTheme.Id);
    }

    private void CreateOptions()
    {
        int i = 0;
        foreach (var item in _creationConfig.ThemePrefabsMap)
        {
            int id = item.Id;
            bool isUnlocked = _storage.GameData.Theme.ThemeState(id).IsUnlocked;

            if (id == _currentTheme.Theme.Id)
            {
                _themes.Add(_currentTheme.Theme);
                ViewedThemeIndex = i;
                continue;
            }

            Theme theme = _creator.Create(id);

            theme.Init(id, isUnlocked);
            theme.Deactivate();

            _themes.Add(theme);

            i++;
        }
    }

    private void DestroyUnviewedThemes()
    {
        foreach (Theme theme in _themes)
        {
            if (theme != ViewedTheme)
                theme.Destroy();
        }
    }

    private void ClampViewedThemeIndex()
    {
        if (ViewedThemeIndex >= _themes.Count) ViewedThemeIndex = 0;
        if (ViewedThemeIndex < 0) ViewedThemeIndex = _themes.Count - 1;
    }
}
