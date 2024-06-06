using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMoving))]
public class Tile : MonoBehaviour
{
    [field: SerializeField] public Vector2Int Coordinates { get; private set; }
    public TileMoving Moving { get; private set; }
    public TileDots Dots { get; private set; }

    public void Init(Vector2Int coordinates)
    {
        SetCoordinates(coordinates);
        Moving = GetComponent<TileMoving>();
        Dots = GetComponent<TileDots>();
    }

    public void SetCoordinates(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }

    public bool HasDot(DotPosition position)
    {
        foreach (var dot in Dots.Dots)
        {
            if (dot.Position == position)
                return true;
        }

        return false;
    }

    private void OnMouseUp()
    {
        TileSwapper.Select(this);
    }
}
