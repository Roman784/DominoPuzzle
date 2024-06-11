using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Field : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> _tilesMap = new Dictionary<Vector2Int, Tile>();
    private List<Tile> _tiles = new List<Tile>();

    private float _tileSpacing;

    private FieldShuffler _shuffler;
    private FieldAnimation _animation;
    private FieldAnimationConfig _animationConfig;

    [Inject]
    private void Construct(FieldConfig config, FieldAnimationConfig animationConfig)
    {
        _tileSpacing = config.TileSpacing;
        _animationConfig = animationConfig;
    }

    private void Awake()
    {
        _shuffler = new FieldShuffler(this);
        _animation = new FieldAnimation(this, _animationConfig);
    }

    private void Start()
    {
        _tiles = FindObjectsOfType<Tile>().ToList();

        InitTiles(_tiles);

        _shuffler.Shuffle();
        _animation.TileAppearance();
    }

    private void InitTiles(List<Tile> tiles)
    {
        Vector2 minPosition = GetMinimalTilePosition(tiles);

        foreach (Tile tile in tiles)
        {
            Vector2 relativePosition = (Vector2)tile.transform.position - minPosition;
            Vector2Int coordinates = RoundVectorToInt(relativePosition / _tileSpacing);

            _tilesMap.Add(coordinates, tile);
            tile.Init(coordinates, this);
        }
    }

    public IReadOnlyDictionary<Vector2Int, Tile> TilesMap => _tilesMap;
    public IEnumerable<Tile> Tiles => _tiles;
    public FieldShuffler Shuffler => _shuffler;
    public FieldAnimation Animation => _animation;

    public void SetTile(Tile tile, Vector2Int coordinates)
    {
        _tilesMap[coordinates] = tile;
        tile.SetCoordinates(coordinates);
    }

    public bool HasTile(Vector2Int coordinates)
    {
        return _tilesMap.ContainsKey(coordinates);
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
