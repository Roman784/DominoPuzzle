using System;
using Unity.VisualScripting;
using Zenject;

public class CurrentTheme
{
    public static int id; // <- убрать и заменить на загрузку из бд

    private Theme _theme;
    private ThemeCreator _themeCreator;

    public event Action<Theme> OnThemeChanged;

    [Inject]
    private void Construct(ThemeCreator themeCreator)
    {
        _themeCreator = themeCreator;

        Create(id);
    }

    public Theme Theme => _theme;
    public ThemeConfig Config => _theme.Config;

    public void Destroy()
    {
        _theme?.Destroy();
    }

    public void InvokeThemeChangedEvent(Theme theme)
    {
        OnThemeChanged?.Invoke(theme);
    }

    private void Create(int _id) // <-
    {
        Theme theme = _themeCreator.Create(_id);
        theme.DeactivateTitle();

        _theme = theme;
        OnThemeChanged?.Invoke(theme);
    }
}
