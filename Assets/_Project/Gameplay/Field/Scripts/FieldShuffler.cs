using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldShuffler
{
    private Field _field;

    public FieldShuffler(Field field)
    {
        _field = field;
    }

    public void Shuffle()
    {
        List<Tile> tiles = _field.Tiles.ToList();

        foreach (Tile tile1 in tiles)
        {
            Tile tile2 = tiles[Random.Range(0, tiles.Count)];

            if (tile1.Locker.IsLocked || tile2.Locker.IsLocked)
                continue;

            SwapTiles(tile1, tile2);
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
