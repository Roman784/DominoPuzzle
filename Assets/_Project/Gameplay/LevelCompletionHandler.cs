using System;
using UnityEngine.Events;
using Zenject;

public class LevelCompletionHandler : IInitializable, IDisposable
{
    public UnityEvent OnCompleted = new UnityEvent();
    private bool _isCompleted;

    private Storage _storage;
    private SDK _SDK;
    private Field _field;
    private ITileBehavior _tileBehavior;
    private ITileMatcher _tileMatcher;

    [Inject]
    private void Construct(Storage storage, SDK SDK, Field field,
                           ITileBehavior tileBehavior, ITileMatcher tileMatcher)
    {
        _storage = storage;
        _SDK = SDK;
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

        _SDK.ShowFullscreenAdv();

        if (OpeningLevel.Number > _storage.GameData.Level.LastCompletedLevelNumber)
            _storage.SetLastCompletedLevelNumber(OpeningLevel.Number);

        _field.Sound.PlayFieldCompleteSound();

        OnCompleted?.Invoke();
    }
}
