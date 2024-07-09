using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelCompletionHandler : IInitializable, IDisposable
{
    private bool _isCompleted;

    private Storage _storage;
    private Field _field;
    private FieldCreationConfig _fieldCreationConfig;
    private ITileBehavior _tileBehavior;
    private ITileMatcher _tileMatcher;
    SceneNamesConfig _sceneNames;
    SceneTransitionEffect _sceneTransitionEffect;

    [Inject]
    private void Construct(Storage storage, Field field, FieldCreationConfig fieldCreationConfig, ITileBehavior tileBehavior, ITileMatcher tileMatcher, SceneNamesConfig sceneNames, SceneTransitionEffect sceneTransitionEffect)
    {
        _storage = storage;
        _field = field;
        _fieldCreationConfig = fieldCreationConfig;
        _tileBehavior = tileBehavior;
        _tileMatcher = tileMatcher;
        _sceneNames = sceneNames;
        _sceneTransitionEffect = sceneTransitionEffect;
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
        if (OpeningLevel.Number > _storage.GameData.Level.LastCompletedLevelNumber)
            _storage.SetLastCompletedLevelNumber(OpeningLevel.Number);

        _field.Sound.PlayFieldCompleteSound();

        yield return new WaitForSeconds(0.15f);

        _field.Animation.TileDisappearance();
        _field.Sound.PlayTileDisappearanceSound();

        yield return new WaitForSeconds(1.5f);

        yield return _sceneTransitionEffect.Appearance();

        OpeningLevel.Next();

        if (OpeningLevel.Number >= _fieldCreationConfig.MaxNumber)
            SceneManager.LoadScene(_sceneNames.LevelList);
        else
            SceneManager.LoadScene(_sceneNames.GameplayScene);
    }
}
