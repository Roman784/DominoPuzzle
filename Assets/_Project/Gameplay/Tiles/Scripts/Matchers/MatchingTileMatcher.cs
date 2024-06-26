using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MatchingTileMatcher : ITileMatcher
{
    private Vector2Int[] _tileDirections = new Vector2Int[4]
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    // Map of the correct adjacency depending on the position and direction of the tiles.
    private Dictionary<DotPosition, Dictionary<Vector2Int, DotPosition>> _dotAdjacencyMap;

    private Field _field;

    [Inject]
    private void Construct(Field field)
    {
        _field = field;
    }

    private MatchingTileMatcher()
    {
        InitDotAdjacencyMap();
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

    public bool MatchTiles()
    {
        foreach (Tile tile in _field.Tiles)
        {
            if (!MatchAdjacentTiles(tile))
                return false;
        }

        return true;
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
        if (!_field.HasTile(coordinates)) return true;

        Tile tile = _field.TilesMap[coordinates];
        Vector2Int direction = tile.Coordinates - originTile.Coordinates;

        return MatchDots(originTile.Dots, tile.Dots, direction);
    }

    private bool MatchDots(IEnumerable<TileDot> originDots, IEnumerable<TileDot> dots, Vector2Int direction)
    {
        foreach (var originDot in originDots)
        {
            if (!_dotAdjacencyMap[originDot.Position].ContainsKey(direction))
                continue;

            bool hasDot = false;

            foreach (var dot in dots)
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
