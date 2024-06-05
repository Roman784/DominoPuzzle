using UnityEngine;

[RequireComponent(typeof(TileMoving))]
public class Tile : MonoBehaviour
{
    public Vector2Int Coordinates { get; private set; }
    public TileMoving Moving { get; private set; }

    public void Init(Vector2Int coordinates)
    {
        SetCoordinates(coordinates);
        Moving = GetComponent<TileMoving>();
    }

    public void SetCoordinates(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }

    private void OnMouseUp()
    {
        TileSwapper.Select(this);
    }
}
