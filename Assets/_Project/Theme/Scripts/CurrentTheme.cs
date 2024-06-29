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

        SetTheme(0); // <- id θη αδ
    }

    public Theme Theme => _theme;
    public ThemeConfig Config => _theme.Config;

    public void SetTheme(int id)
    {
        _theme?.Destroy();

        Theme theme = _themeCreator.Create(id);
        theme.DeactivateTitle();
        theme.Sound.PlaySoundtrack();

        GameObject.DontDestroyOnLoad(theme);

        _theme = theme;
        OnThemeChanged?.Invoke(theme);
    }
}
