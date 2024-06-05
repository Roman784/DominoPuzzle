using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> _tilesByCoordinates = new Dictionary<Vector2Int, Tile>();

    [SerializeField] private float _tileSpacing;

    private void Start()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();

        InitTiles(tiles);
    }

    private void InitTiles(Tile[] tiles)
    {
        Vector2 minPosition = GetMinTilesPosition(tiles);

        foreach (Tile tile in tiles)
        {
            Vector2 relativePosition = (Vector2)tile.transform.position - minPosition;
            Vector2Int coordinates = RoundVectorToInt(relativePosition / _tileSpacing);

            _tilesByCoordinates.Add(coordinates, tile);
            tile.Init(coordinates);
        }
    }

    private Vector2 GetMinTilesPosition(Tile[] tiles)
    {
        Vector2 position = Vector2.zero;

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
