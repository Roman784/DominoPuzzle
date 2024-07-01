using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FieldAnimation
{
    private Field _field;
    private FieldAnimationConfig _config;

    private float _tileAppearanceDelay;
    private float _tileDisappearanceDelay;

    public FieldAnimation(Field field, FieldAnimationConfig config)
    {
        _field = field;
        _config = config;
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

        foreach (Tile tile in _field.Tiles)
        {
            tile.Animation.Appearance();

            yield return new WaitForSeconds(_config.TileAppearanceDelay);
        }
    }

    private IEnumerator TileDisppearanceRoutine()
    {
        foreach (Tile tile in _field.Tiles)
        {
            tile.Animation.Disappearance();

            yield return new WaitForSeconds(_config.TileDisappearanceDelay);
        }
    }
}
