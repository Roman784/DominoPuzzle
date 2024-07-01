using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class LevelCompletionHandler : IInitializable, IDisposable
{
    private bool _isCompleted;

    private Field _field;
    private ITileBehavior _tileBehavior;
    private ITileMatcher _tileMatcher;

    [Inject]
    private void Construct(Field field, ITileBehavior tileBehavior, ITileMatcher tileMatcher)
    {
        _field = field;
        _tileBehavior = tileBehavior;
        _tileMatcher = tileMatcher;
    }

    public void Initialize()
    {
        _isCompleted = false;

        _tileBehavior.OnCompleted += MatchTiles;
    }

    public void Dispose()
    {
        _tileBehavior.OnCompleted -= MatchTiles;
    }

    public bool IsCompleted => _isCompleted;

    private void MatchTiles()
    {
        bool isMatched = _tileMatcher.MatchTiles();

        if (isMatched)
            CompleteLevel();
    }

    private void CompleteLevel()
    {
        if (_isCompleted) return;
        _isCompleted = true;

        Coroutines.StartRoutine(CompleteLeverRoutine());
    }

    private IEnumerator CompleteLeverRoutine()
    {
        _field.Sound.PlayFieldCompleteSound();

        yield return new WaitForSeconds(0.5f);

        _field.Animation.TileDisappearance();
        _field.Sound.PlayTileDisappearanceSound();
    }
}
