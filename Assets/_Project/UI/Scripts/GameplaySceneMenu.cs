using System.Linq;
using Zenject;

public class GameplaySceneMenu : PanelMenu
{
    private Field _field;
    private HintGiver _hintGiver;
    private IFieldShuffling _shuffling;

    [Inject]
    private void Constructor(FieldCreator fieldCreator, HintGiver hintGiver, IFieldShuffling shuffling)
    {
        _field = fieldCreator.CreatedField;
        _hintGiver = hintGiver;
        _shuffling = shuffling;
    }

    public void ShuffleField()
    {
        var tiles = _field.Tiles.ToList();
        _shuffling.Shuffle(tiles);
    }

    public void UseHint()
    {
        _hintGiver.UseHint();
    }
}
