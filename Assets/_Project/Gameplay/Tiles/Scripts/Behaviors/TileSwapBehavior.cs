using System;
using UnityEngine;
using Zenject;

public class TileSwapBehavior : ITileBehavior
{
    public event Action OnCompleted;

    private Tile _selectedTile;

    private Field _field;

    [Inject]
    private void Construct(Field field)
    {
        _field = field;
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
            _selectedTile.Sound.PlayFallSound();
            Deselect();
            return;
        }

        Swap(tile, _selectedTile);

        Deselect();
    }

    private void Select(Tile tile)
    {
        tile.Animation.Selection();
        tile.Sound.PlayLiftSound();
        _selectedTile = tile;
    }

    public void Deselect()
    {
        if (_selectedTile == null) return;

        _selectedTile.Animation.Deselection();
        _selectedTile = null;
    }

    public void Swap(Tile tile1, Tile tile2)
    {
        TileData tileData1 = new TileData(tile1, _field);
        TileData tileData2 = new TileData(tile2, _field);

        _field.SetTile(tile1, tileData2.Coordinates);
        _field.SetTile(tile2, tileData1.Coordinates);

        tile1.Moving.Move(tileData2.Position);
        tile2.Moving.Move(tileData1.Position);

        tile1.Sound.PlayFallSound();

        OnCompleted?.Invoke();
    }

    public void InstantSwap(Tile tile1, Tile tile2)
    {
        TileData tileData1 = new TileData(tile1, _field);
        TileData tileData2 = new TileData(tile2, _field);

        _field.SetTile(tile1, tileData2.Coordinates);
        _field.SetTile(tile2, tileData1.Coordinates);

        tile1.transform.position = tileData2.Position;
        tile2.transform.position = tileData1.Position;

        OnCompleted?.Invoke();
    }

    private struct TileData
    {
        public Vector2Int Coordinates;
        public Vector2 Position;

        public TileData(Tile tile, Field field)
        {
            Coordinates = tile.Coordinates;
            Position = field.GetTilePosition(tile.Coordinates);
        }
    }
}
