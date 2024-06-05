using UnityEngine;

public class Tile : MonoBehaviour
{
    [field: SerializeField] public Vector2Int Coordinates { get; private set; }

    public void Init(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }
}
