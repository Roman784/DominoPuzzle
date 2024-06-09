using System;
using UnityEngine;
using Zenject;

public class TileSwapBehavior : ITileBehavior
{
    public event Action OnCompleted;

    private Tile _selectedTile;

    private Field _field;

    [Inject]
    private void Construct(FieldCreator fieldCreator)
    {
        _field = fieldCreator.CreatedField;
    }

    public void OnClick(Tile tile)
    {
        if (_selectedTile == null)
        {
            Select(tile);
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

    private void Select(Tile tile)
    {
        tile.Animation.Selection();
        _selectedTile = tile;
    }

    private void Deselect()
    {
        _selectedTile.Animation.Deselection();
        _selectedTile = null;
    }

    private void Swap(Tile tile1, Tile tile2)
    {
        Vector2Int coordinates = tile1.Coordinates;
        Vector2 position = tile1.transform.position;

        _field.SetTile(tile1, tile2.Coordinates);
        _field.SetTile(tile2, coordinates);

        tile1.Moving.Move(tile2.transform.position);
        tile2.Moving.Move(position);

        OnCompleted?.Invoke();
    }
}
