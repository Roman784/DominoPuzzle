using Zenject;

public class CurrentTheme
{
    public static int id; // <- убрать и заменить на загрузку из бд

    private Theme _theme;
    private ThemeCreator _themeCreator;

    [Inject]
    private void Construct(ThemeCreator themeCreator)
    {
        _themeCreator = themeCreator;

        Create();
    }

    public Theme Theme => _theme;
    public ThemeConfig Config => _theme.Config;

    public void Destroy()
    {
        _theme?.Destroy();
    }

    private void Create()
    {
        Theme theme = _themeCreator.Create(id);
        theme.DeactivateTitle();

        _theme = theme;
    }
}
