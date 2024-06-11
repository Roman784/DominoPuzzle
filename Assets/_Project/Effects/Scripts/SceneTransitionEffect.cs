using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionEffect : MonoBehaviour
{
    [SerializeField] private float _appearanceDuration;
    [SerializeField] private AnimationCurve _appearanceCurve;

    [SerializeField] private float _disappearanceDuration;
    [SerializeField] private AnimationCurve _disappearanceCurve;

    [Space]

    [SerializeField] private Image _view;

    public Coroutine Appearance()
    {
        return StartCoroutine(AnimateRoutine(_appearanceDuration, _appearanceCurve));
    }

    public Coroutine Disappearance()
    {
        return StartCoroutine(AnimateRoutine(_disappearanceDuration, _disappearanceCurve));
    }

    private IEnumerator AnimateRoutine(float duration, AnimationCurve curve)
    {
        _view.color = new Color(_view.color.r, _view.color.g, _view.color.b, curve.Evaluate(0));

        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            float a = curve.Evaluate(time / duration);
            _view.color = new Color(_view.color.r, _view.color.g, _view.color.b, a);

            yield return null;
        }

        _view.color = new Color(_view.color.r, _view.color.g, _view.color.b, curve.Evaluate(1));
    }
}
