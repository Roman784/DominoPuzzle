using System;
using UnityEngine;
using Zenject;

public class CurrentTheme
{
    private Theme _theme;
    private ThemeCreator _themeCreator;

    public event Action<Theme> OnThemeChanged;

    [Inject]
    private void Construct(ThemeCreator themeCreator)
    {
        _themeCreator = themeCreator;
    }

    public Theme Theme => _theme;
    public ThemeConfig Config => _theme.Config;

    public void Set(int id)
    {
        Theme theme = _themeCreator.Create(id);
        theme.Init(id);
        SetExisting(theme);
    }

    public void SetExisting(Theme theme)
    {
        if (_theme != theme)
            _theme?.Destroy();

        GameObject.DontDestroyOnLoad(theme);

        theme.ActivateBackground();
        theme.DeactivateTitle();
        theme.Sound.PlaySoundtrack();

        _theme = theme;
        OnThemeChanged?.Invoke(theme);
    }
}
