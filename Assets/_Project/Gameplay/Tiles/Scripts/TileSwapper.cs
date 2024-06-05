using UnityEngine;

public static class TileSwapper
{
    private static Tile _selectedTile;
    
    public static void Select(Tile tile)
    {
        if (_selectedTile == null)
        {
            _selectedTile = tile;
            return;
        }

        if (tile == _selectedTile)
        {
            Deselect();
            return;
        }

        Swap(tile, _selectedTile);

        Deselect();
    }

    private static void Deselect()
    {
        _selectedTile = null;
    }

    private static void Swap(Tile tile1, Tile tile2)
    {
        Vector2Int coordinates = tile1.Coordinates;
        Vector2 position = tile1.transform.position;

        Field.Instance.SetTileCoordinates(tile1, tile2.Coordinates);
        Field.Instance.SetTileCoordinates(tile2, coordinates);

        tile1.Moving.Move(tile2.transform.position);
        tile2.Moving.Move(position);
    }
}
