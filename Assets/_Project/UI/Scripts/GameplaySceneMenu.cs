using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private HintGiver _hintGiver;

    [Inject]
    private void Constructor(FieldCreator fieldCreator, HintGiver hintGiver)
    {
        _field = fieldCreator.CreatedField;
        _hintGiver = hintGiver;
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
