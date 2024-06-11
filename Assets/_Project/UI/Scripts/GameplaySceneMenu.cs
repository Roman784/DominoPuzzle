using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;

    [Inject]
    private void Constructor(FieldCreator fieldCreator)
    {
        _field = fieldCreator.CreatedField;
    }

    public void ShuffleField()
    {
        _field.Shuffler.Shuffle();
    }
}
