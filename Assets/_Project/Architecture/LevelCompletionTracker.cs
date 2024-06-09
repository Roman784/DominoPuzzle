using UnityEngine;
using Zenject;

public class LevelCompletionTracker : MonoBehaviour
{
    private Field _field;

    private ITileBehavior _tileBehavior;
    private ITileMatcher _tileMatcher;

    [Inject]
    private void Construct(FieldCreator fieldCreator, ITileBehavior tileBehavior, ITileMatcher tileMatcher)
    {
        _field = fieldCreator.CreatedField;

        _tileBehavior = tileBehavior;
        _tileMatcher = tileMatcher;
    }

    private void OnEnable()
    {
        _tileBehavior.OnCompleted += MatchTiles;
    }

    private void OnDisable()
    {
        _tileBehavior.OnCompleted -= MatchTiles;
    }

    private void MatchTiles()
    {
        bool isMatched = _tileMatcher.MatchTiles();

        if (isMatched)
        {
            _field.Animation.TileDisappearance();
        }
    }
}
