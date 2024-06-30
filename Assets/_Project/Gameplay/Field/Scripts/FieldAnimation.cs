using System.Collections;
using UnityEngine;

public class FieldAnimation
{
    private Field _field;

    private float _tileAppearanceDelay;
    private float _tileDisappearanceDelay;

    public FieldAnimation(Field field, FieldAnimationConfig config)
    {
        _field = field;

        _tileAppearanceDelay = config.TileAppearanceDelay;
        _tileDisappearanceDelay = config.TileDisappearanceDelay;
    }

    public void TileAppearance()
    {
        Coroutines.StartRoutine(TileAppearanceRoutine());
    }

    public void TileDisappearance()
    {
        Coroutines.StartRoutine(TileDisppearanceRoutine());
    }

    private IEnumerator TileAppearanceRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        int i = 0;
        foreach (Tile tile in _field.Tiles)
        {
            tile.Animation.Appearance();
            if (i % 2 == 1) tile.Sound.PlayFallSound();

            i++;
            yield return new WaitForSeconds(_tileAppearanceDelay);
        }
    }

    private IEnumerator TileDisppearanceRoutine()
    {
        foreach (Tile tile in _field.Tiles)
        {
            tile.Animation.Disappearance();

            yield return new WaitForSeconds(_tileDisappearanceDelay);
        }
    }
}
