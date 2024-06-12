using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private SceneNamesConfig _sceneNames;
    private HintGiver _hintGiver;

    [Inject]
    private void Constructor(FieldCreator fieldCreator, SceneNamesConfig sceneNames, HintGiver hintGiver)
    {
        _field = fieldCreator.CreatedField;
        _sceneNames = sceneNames;
        _hintGiver = hintGiver;
    }

    public void OpenLevelList()
    {
        OpenScene(_sceneNames.LevelList);
    }

    public void ShuffleField()
    {
        _field.Shuffler.Shuffle();
    }

    public void UseHint()
    {
        _hintGiver.UseHint();
    }
}
