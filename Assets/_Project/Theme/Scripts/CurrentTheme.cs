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

        Set(0); // <- id θη αδ

        _theme.ActivateBackground();
        _theme.DeactivateTitle();
        _theme.Sound.PlaySoundtrack();
    }

    public Theme Theme => _theme;
    public ThemeConfig Config => _theme.Config;

    public void Set(int id)
    {
        Theme theme = _themeCreator.Create(id);
        SetExisting(theme);
    }

    public void SetExisting(Theme theme)
    {
        if (_theme != theme)
            _theme?.Destroy();

        GameObject.DontDestroyOnLoad(theme);

        _theme = theme;
        OnThemeChanged?.Invoke(theme);
    }
}
