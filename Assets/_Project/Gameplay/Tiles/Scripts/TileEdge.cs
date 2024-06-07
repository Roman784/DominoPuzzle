using UnityEngine;

public class TileEdge : MonoBehaviour
{
    [SerializeField] private Transform _face;
    [SerializeField] private Transform _edge;

    [SerializeField] private Vector2 _offset;

    private void Update()
    {
        Vector2 position = (Vector2)_face.position + _offset;
        _edge.position = position;
    }
}
