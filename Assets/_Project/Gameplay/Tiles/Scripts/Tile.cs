using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator), typeof(TileLocker), typeof(TileDot))]
public class Tile : MonoBehaviour
{
    private Vector2Int _coordinates;

    private TileDots _dots;
    private TileLocker _locker;
    private TileMoving _moving;
    private TileAnimation _animation;
    
    private ITileBehavior _behavior;
    private TileConfig _config;

    private Field _field;
    private TileColorizer _colorizer;

    [SerializeField] private SpriteRenderer _faceView;
    [SerializeField] private SpriteRenderer _edgeView;

    [Inject]
    private void Construct(ITileBehavior behavior, TileConfig config, TileColorizer colorizer)
    {
        _behavior = behavior;
        _config = config;
        _colorizer = colorizer;
    }

    private void Awake()
    {
        Animator animator = GetComponent<Animator>();

        _dots = GetComponent<TileDots>();
        _locker = GetComponent<TileLocker>();
        _moving = new TileMoving(transform, _config.MoveSpeed);
        _animation = new TileAnimation(animator);
    }

    public void Init(Vector2Int coordinates, Field field)
    {
        _coordinates = coordinates;
        _field = field;

        _colorizer.Color(Dots, _faceView, _edgeView);
    }

    public Vector2Int Coordinates => _coordinates;
    public IEnumerable<TileDot> Dots => _dots.Dots;
    public TileLocker Locker => _locker;
    public TileMoving Moving => _moving;
    public TileAnimation Animation => _animation;

    public void SetCoordinates(Vector2Int coordinates)
    {
        if (_field.TilesMap[coordinates] != this)
            throw new Exception("The coordinates are already used by another tile. " +
                                "You can change the coordinates using the Field class.");

        _coordinates = coordinates;
    }

    private void OnMouseUp()
    {
        if (!_locker.IsLocked)
            _behavior.OnClick(this);
    }
}
