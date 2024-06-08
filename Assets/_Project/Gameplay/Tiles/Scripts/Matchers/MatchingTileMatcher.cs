using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MatchingTileMatcher : ITileMatcher, IInitializable, IDisposable
{
    private Vector2Int[] _tileDirections = new Vector2Int[4]
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    private Dictionary<DotPosition, Dictionary<Vector2Int, DotPosition>> _dotAdjacencyMap;

    private ITileBehavior _tileBehavior;
    private Field _field;

    [Inject]
    private void Construct(ITileBehavior tileBehavior, Field field)
    {
        _tileBehavior = tileBehavior;
        _field = field;
    }

    private MatchingTileMatcher()
    {
        InitDotAdjacencyMap();
    }

    public void Initialize()
    {
        _tileBehavior.OnCompleted += MatchTiles;
    }

    public void Dispose()
    {
        _tileBehavior.OnCompleted -= MatchTiles;
    }

    private void InitDotAdjacencyMap()
    {
        _dotAdjacencyMap = new Dictionary<DotPosition, Dictionary<Vector2Int, DotPosition>>();

        _dotAdjacencyMap[DotPosition.TopLeft] = new Dictionary<Vector2Int, DotPosition>()
        {
            [Vector2Int.up] = DotPosition.BottomLeft,
            [Vector2Int.left] = DotPosition.TopRight
        };

        _dotAdjacencyMap[DotPosition.TopRight] = new Dictionary<Vector2Int, DotPosition>()
        {
            [Vector2Int.up] = DotPosition.BottomRight,
            [Vector2Int.right] = DotPosition.TopLeft
        };

        _dotAdjacencyMap[DotPosition.BottomRight] = new Dictionary<Vector2Int, DotPosition>()
        {
            [Vector2Int.down] = DotPosition.TopRight,
            [Vector2Int.right] = DotPosition.BottomLeft
        };

        _dotAdjacencyMap[DotPosition.BottomLeft] = new Dictionary<Vector2Int, DotPosition>()
        {
            [Vector2Int.down] = DotPosition.TopLeft,
            [Vector2Int.left] = DotPosition.BottomRight
        };
    }

    public void MatchTiles()
    {
        IReadOnlyDictionary<Vector2Int, Tile> tiles = _field.TilesByCoordinates;

        bool isWin = true;

        foreach (var item in tiles)
        {
            Tile tile = item.Value;

            if (!MatchAdjacentTiles(tile))
            {
                isWin = false;
                break;
            }
        }

        if (isWin)
        {
            List<Tile> tileList = new List<Tile>();
            foreach(var item in tiles)
            {
                tileList.Add(item.Value);
            }

            _field.Animation.TileDisappearance(tileList.ToArray());
        }
    }

    private bool MatchAdjacentTiles(Tile originTile)
    {
        foreach (var direction in _tileDirections)
        {
            Vector2Int coordinates = originTile.Coordinates + direction;

            if (!MatchAdjacentTile(originTile, coordinates))
                return false;
        }

        return true;
    }

    private bool MatchAdjacentTile(Tile originTile, Vector2Int coordinates)
    {
        IReadOnlyDictionary<Vector2Int, Tile> tiles = _field.TilesByCoordinates;

        if (!_field.HasTile(coordinates)) return true;

        Tile tile = tiles[coordinates];

        return MatchDots(originTile, tile);
    }

    private bool MatchDots(Tile originTile, Tile tile)
    {
        IEnumerable<TileDot> originDots = originTile.Dots.Dots;
        Vector2Int direction = tile.Coordinates - originTile.Coordinates;

        foreach (var originDot in originDots)
        {
            if (!_dotAdjacencyMap[originDot.Position].ContainsKey(direction))
                continue;

            bool hasDot = false;

            foreach (var dot in tile.Dots.Dots)
            {
                if (_dotAdjacencyMap[originDot.Position][direction] == dot.Position)
                {
                    hasDot = true;
                    break;
                }
            }

            if (!hasDot)
                return false;
        }

        return true;
    }
}
