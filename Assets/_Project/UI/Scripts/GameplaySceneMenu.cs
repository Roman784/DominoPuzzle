using System.Linq;
using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private IHint _hint;
    private IFieldShuffling _shuffling;

    [Inject]
    private void Constructor(FieldCreator fieldCreator, IHint hint, IFieldShuffling shuffling)
    {
        _field = fieldCreator.CreatedField;
        _hint = hint;
        _shuffling = shuffling;
    }

    public void ShuffleField()
    {
        var tiles = _field.Tiles.ToList();
        _shuffling.Shuffle(tiles);
    }

    public void UseHint()
    {
        _hint.Use();
    }
}
