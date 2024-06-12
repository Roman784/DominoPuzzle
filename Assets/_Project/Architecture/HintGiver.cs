using UnityEngine;
using Zenject;

public class HintGiver
{
    private Field _field;

    [Inject]
    private void Construct(FieldCreator fieldCreator)
    {
        _field = fieldCreator.CreatedField;
    }

    public void UseHint()
    {
        foreach (var item in _field.CorrectTilesMap)
        {
            Tile tile = item.Value;
            Vector2Int coordinates = item.Key;

            if (!tile.Locker.IsLocked)
            {
                Tile tile2 = _field.TilesMap[coordinates];

                SwapTiles(tile, tile2);
                tile.Locker.Lock();

                break;
            }
        }
    }

    private void SwapTiles(Tile tile1, Tile tile2)
    {
        Vector2Int coordinates = tile1.Coordinates;
        Vector2 position = tile1.transform.position;

        _field.SetTile(tile1, tile2.Coordinates);
        _field.SetTile(tile2, coordinates);

        tile1.transform.position = tile2.transform.position;
        tile2.transform.position = position;
    }
}
