using System.Collections.Generic;
using UnityEngine;

public class TileMatcher : MonoBehaviour
{
    private Vector2Int[] _tileDirections = new Vector2Int[4]
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    private Dictionary<DotPosition, Dictionary<Vector2Int, DotPosition>> _dotAdjacencyMap;

    private void Awake()
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

    public void MatchTiles()
    {
        IReadOnlyDictionary<Vector2Int, Tile> tiles = Field.Instance.TilesByCoordinates;

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

            Field.Instance.Animation.TileDisappearance(tileList.ToArray());
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
        IReadOnlyDictionary<Vector2Int, Tile> tiles = Field.Instance.TilesByCoordinates;

        if (!Field.Instance.HasTile(coordinates)) return true;

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
