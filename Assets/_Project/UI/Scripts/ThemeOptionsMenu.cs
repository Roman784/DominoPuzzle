using UnityEngine;
using Zenject;

public class ThemeOptionsMenu : SceneMenu
{
    private ThemeOptions _options;

    [Inject]
    private void Construct (Storage storage, CurrentTheme currentTheme, ThemeCreator creator, ThemeCreationConfig creationConfig)
    {
        _options = new ThemeOptions(storage, currentTheme, creator, creationConfig);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SwitchToNext();
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            SwitchToPrevious();
    }

    public void Select()
    {
        _options.Select();
        OpenGameplayScene();
    }

    public void SwitchToNext()
    {
        PlayButtonCLickSound();
        _options.Switch(1);
    }

    public void SwitchToPrevious()
    {
        PlayButtonCLickSound();
        _options.Switch(-1);
    }
}
