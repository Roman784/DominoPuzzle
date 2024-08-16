using System;
using UnityEngine;
using Zenject;

public class TileSwapHint : IHint
{
    private Field _field;
    private TileSwapBehavior _tileSwap;

    [Inject]
    private void Construct(Field field, ITileBehavior tileBehavior)
    {
        if (tileBehavior is not TileSwapBehavior)
            throw new Exception("Ñonflict of tile behavior and hints.");

        _tileSwap = (TileSwapBehavior)tileBehavior;
        _field = field;
    }

    public void Use()
    {
        foreach (var item in _field.CorrectTilesMap)
        {
            Tile tile = item.Value;
            Vector2Int coordinates = item.Key;

            if (!tile.Locker.IsLocked)
            {
                Tile tile2 = _field.TilesMap[coordinates];

                _tileSwap.Deselect();

                _tileSwap.Swap(tile, tile2);
                tile.Locker.Lock();

                break;
            }
        }
    }
}
