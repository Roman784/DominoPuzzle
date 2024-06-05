using System.Collections;
using UnityEngine;

public class TileMoving : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector2 position)
    {
        StartCoroutine(MoveRoutine(position, Time.fixedDeltaTime));
    }

    private IEnumerator MoveRoutine(Vector2 position, float delta)
    {
        float distanceToTarget;
        do
        {
            transform.position = Vector2.Lerp(transform.position, position, _speed * delta);
            distanceToTarget = Vector2.Distance(transform.position, position);

            yield return null;

        } while (distanceToTarget > 0.05f);

        transform.position = position;
    }
}
