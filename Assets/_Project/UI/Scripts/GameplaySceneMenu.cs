using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private SceneNamesConfig _sceneNames;

    [Inject]
    private void Constructor(FieldCreator fieldCreator, SceneNamesConfig sceneNames)
    {
        _field = fieldCreator.CreatedField;
        _sceneNames = sceneNames;
    }

    public void OpenLevelList()
    {
        OpenScene(_sceneNames.LevelList);
    }

    public void ShuffleField()
    {
        _field.Shuffler.Shuffle();
    }
}
