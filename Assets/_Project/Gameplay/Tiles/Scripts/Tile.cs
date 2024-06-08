using UnityEngine;
using Zenject;

[RequireComponent(typeof(TileMoving))]
public class Tile : MonoBehaviour
{
    [field: SerializeField] public Vector2Int Coordinates { get; private set; }
    public TileMoving Moving { get; private set; }
    public TileAnimation Animation { get; private set; }
    public TileDots Dots { get; private set; }

    private ITileBehavior _behavior;

    [Inject]
    private void Construct(ITileBehavior behavior)
    {
        _behavior = behavior;
    }

    public void Init(Vector2Int coordinates)
    {
        SetCoordinates(coordinates);
        Moving = GetComponent<TileMoving>();
        Animation = GetComponent<TileAnimation>();
        Dots = GetComponent<TileDots>();
    }

    public void SetCoordinates(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }

    private void OnMouseUp()
    {
        _behavior.OnClick(this);
    }
}
