using UnityEngine;
using Zenject;

public class HintGiver
{
    private Field _field;
    private ITileBehavior _tileBehavior;

    [Inject]
    private void Construct(FieldCreator fieldCreator, ITileBehavior tileBehavior)
    {
        _field = fieldCreator.CreatedField;
        _tileBehavior = tileBehavior;
    }

    public void UseHint()
    {
        if (_tileBehavior is TileSwapBehavior)
            UseHintForSwapTileBehavior();
    }

    private void UseHintForSwapTileBehavior()
    {
        TileSwapBehavior tileSwap = (TileSwapBehavior)_tileBehavior;

        foreach (var item in _field.CorrectTilesMap)
        {
            Tile tile = item.Value;
            Vector2Int coordinates = item.Key;

            if (!tile.Locker.IsLocked)
            {
                Tile tile2 = _field.TilesMap[coordinates];

                tileSwap.Swap(tile, tile2);
                tile.Locker.Lock();

                break;
            }
        }
    }
}
