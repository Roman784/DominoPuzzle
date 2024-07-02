public class SceneMenu : Menu
{
    public void OpenThemeOptionsScene()
    {
        PlayButtonCLickSound();

        OpenScene(SceneNames.ThemeOptions);
    }

    public void OpenLevelListScene()
    {
        PlayButtonCLickSound();

        OpenScene(SceneNames.LevelList);
    }

    public void OpenGameplayScene()
    {
        PlayButtonCLickSound();

        OpenScene(SceneNames.GameplayScene);
    }
}
