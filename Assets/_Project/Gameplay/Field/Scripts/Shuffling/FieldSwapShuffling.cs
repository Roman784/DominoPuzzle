using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FieldSwapShuffling : IFieldShuffling
{
    private float _tileShufflingDelay;
    private TileSwapBehavior _tileSwap;

    [Inject]
    private void Construct(ITileBehavior tileBehavior, FieldAnimationConfig animationConfig)
    {
        if (tileBehavior is TileSwapBehavior)
            _tileSwap = (TileSwapBehavior)tileBehavior;

        _tileShufflingDelay = animationConfig.TileShufflingDelay;
    }

    public void Shuffle(List<Tile> tiles)
    {
        Coroutines.StartRoutine(ShuffleRoutine(tiles, _tileShufflingDelay));
    }

    public void InstantShuffle(List<Tile> tiles)
    {
        Coroutines.StartRoutine(ShuffleRoutine(tiles, 0f, true));
    }

    private IEnumerator ShuffleRoutine(List<Tile> tiles, float delay, bool isInstantSwap = false)
    {
        for (int i = 0; i < tiles.Count / 2; i++)
        {
            int j = Random.Range(tiles.Count / 2, tiles.Count);

            Tile tile1 = tiles[i];
            Tile tile2 = tiles[j];

            if (tile1.Locker.IsLocked || tile2.Locker.IsLocked)
                continue;

            if (isInstantSwap)
                _tileSwap?.InstantSwap(tile1, tile2);
            else
                _tileSwap?.Swap(tile1, tile2);

            yield return new WaitForSeconds(delay);
        }
    }
}
