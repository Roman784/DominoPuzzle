using UnityEngine;

public class TileEdgeShifter : MonoBehaviour
{
    [SerializeField] private Transform _face;
    [SerializeField] private Transform _edge;

    [SerializeField] private Vector2 _offset;

    private void OnValidate()
    {
        Shift();
    }

    private void Update()
    {
        Shift();
    }

    private void Shift()
    {
        Vector2 position = (Vector2)_face.position + _offset;
        _edge.position = position;
    }
}
