using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Field : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> _tilesMap = new Dictionary<Vector2Int, Tile>();
    private Dictionary<Vector2Int, Tile> _correctTilesMap = new Dictionary<Vector2Int, Tile>();
    private List<Tile> _tiles = new List<Tile>();

    private float _tileSpacing;
    private Vector2 _minTilePosition;

    private IFieldShuffling _shuffling;
    private FieldAnimation _animation;
    private FieldAnimationConfig _animationConfig;

    [Inject]
    private void Construct(FieldConfig config, FieldAnimationConfig animationConfig, IFieldShuffling shuffling)
    {
        _tileSpacing = config.TileSpacing;
        _animationConfig = animationConfig;
        _shuffling = shuffling;
    }

    private void Start()
    {
        _animation = new FieldAnimation(this, _animationConfig);

        _tiles = FindObjectsOfType<Tile>().ToList();
        _minTilePosition = GetMinimalTilePosition(_tiles);

        InitTiles(_tiles, _minTilePosition);
        SetCorrectTilesMap(_tilesMap);

        _shuffling.InstantShuffle(_tiles);
        _animation.TileAppearance();
    }

    private void InitTiles(List<Tile> tiles, Vector2 minTilePosition)
    {
        foreach (Tile tile in tiles)
        {
            Vector2 relativePosition = (Vector2)tile.transform.position - minTilePosition;
            Vector2Int coordinates = RoundVectorToInt(relativePosition / _tileSpacing);

            _tilesMap.Add(coordinates, tile);
            tile.Init(coordinates);
        }
    }

    public IReadOnlyDictionary<Vector2Int, Tile> TilesMap => _tilesMap;
    public IReadOnlyDictionary<Vector2Int, Tile> CorrectTilesMap => _correctTilesMap;
    public IEnumerable<Tile> Tiles => _tiles;
    public FieldAnimation Animation => _animation;

    public Vector2 GetTilePosition(Vector2Int coordinates)
    {
        Vector2 relativePosition = (Vector2)coordinates * _tileSpacing;
        Vector2 position = _minTilePosition + relativePosition;

        return position;
    }

    public void SetTile(Tile tile, Vector2Int coordinates)
    {
        _tilesMap[coordinates] = tile;
        tile.SetCoordinates(coordinates);
    }

    public bool HasTile(Vector2Int coordinates)
    {
        return _tilesMap.ContainsKey(coordinates);
    }

    private void SetCorrectTilesMap(Dictionary<Vector2Int, Tile> tilesMap)
    {
        foreach (var item in tilesMap)
        {
            _correctTilesMap.Add(item.Key, item.Value);
        }
    }

    private Vector2 GetMinimalTilePosition(List<Tile> tiles)
    {
        Vector2 position = Vector2.positiveInfinity;

        foreach (Tile tile in tiles)
        {
            if (position.x > tile.transform.position.x)
                position.x = tile.transform.position.x;

            if (position.y > tile.transform.position.y)
                position.y = tile.transform.position.y;
        }

        return position;
    }

    private Vector2Int RoundVectorToInt(Vector2 vector)
    {
        int x = Mathf.RoundToInt(vector.x);
        int y = Mathf.RoundToInt(vector.y);

        return new Vector2Int(x, y);
    }
}
