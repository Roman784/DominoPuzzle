using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ThemeSwitcher : Menu
{
    [SerializeField] private List<Theme> _themes;
    private int _themeIndex = 0;

    [Inject]
    private void Construct(ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
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
        BackgroundCreator.id = _currentTheme.Id; // <- потом заменить на сохранение в бд.
        OpenScene(SceneNames.GameplayScene);
    }

    public void Switch(int step)
    {
        int previousIndex = _themeIndex;
        _themeIndex += step;

        ClampThemeIndex();

        _currentTheme.ActivateFully();
        _currentTheme.Appearance();
        _themes[previousIndex].Disappearance();
    }

    private void CreateThemes(ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        creator.DestroyCreatedTheme();

        foreach (var item in creationConfig.ThemePrefabsMap)
        {
            int id = item.Id;

            Theme theme = creator.Create(id);

            theme.Init(id);
            theme.DeactivateFully();

            _themes.Add(theme);
        }

        for (int i = 0; i < _themes.Count; i++) // <-----------------------------------------------------------
        {
            if (_themes[i].Id == BackgroundCreator.id)
            {
                _themeIndex = i;
                break;
            }
        }

        _themes[_themeIndex].ActivateFully();
    }

    private Theme _currentTheme => _themes[_themeIndex];

    private void ClampThemeIndex()
    {
        if (_themeIndex >= _themes.Count) _themeIndex = 0;
        if (_themeIndex < 0) _themeIndex = _themes.Count - 1;
    }
}
