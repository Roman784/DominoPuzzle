using System.Collections;
using UnityEngine;

public class TileMoving
{
    private Transform _transform;
    private float _speed;

    private Coroutine _currentRoutine;

    public TileMoving(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public void Move(Vector2 position)
    {
        if (_currentRoutine != null)
            Coroutines.StopRoutine(_currentRoutine);

        _currentRoutine = Coroutines.StartRoutine(MoveRoutine(position));
    }

    private IEnumerator MoveRoutine(Vector2 position)
    {
        float distanceToTarget;
        do
        {
            _transform.position = Vector2.Lerp(_transform.position, position, _speed * Time.deltaTime);
            distanceToTarget = Vector2.Distance(_transform.position, position);

            yield return null;

        } while (distanceToTarget > 0.05f);

        _transform.position = position;
    }
}
