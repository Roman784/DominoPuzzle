using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldAnimation : MonoBehaviour
{
    public void TileAppearance(Tile[] tiles)
    {
        StartCoroutine(TileAppearanceRoutine(tiles));
    }

    public void TileDisappearance(Tile[] tiles)
    {
        StartCoroutine(TileDisppearanceRoutine(tiles));
    }

    private IEnumerator TileAppearanceRoutine(Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.Animation.Appearance();

            yield return new WaitForSeconds(0.035f);
        }
    }

    private IEnumerator TileDisppearanceRoutine(Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.Animation.Disappearance();

            yield return new WaitForSeconds(0.035f);
        }
    }
}
