using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TileColorizer
{
    private Dictionary<int, Color> _colorsMap;
    private ThemeConfig _themeConfig;

    [Inject]
    private void Construct(CurrentTheme currentTheme)
    {
        _themeConfig = currentTheme.Config;

        InitColorsMap();
    }

    private void InitColorsMap()
    {
        _colorsMap = new Dictionary<int, Color>();

        _colorsMap[1] = _themeConfig.OneDotColor;
        _colorsMap[2] = _themeConfig.TwoDotColor;
        _colorsMap[3] = _themeConfig.ThreeDotColor;
        _colorsMap[4] = _themeConfig.FourDotColor;
    }

    public void Color(IEnumerable<TileDot> dots, SpriteRenderer face, SpriteRenderer edge)
    {
        ColorDots(dots);
        ColorFace(face);
        ColorEdge(edge);
    }

    private void ColorDots(IEnumerable<TileDot> dots)
    {
        int dotCount = dots.Count();
        Debug.Log(dotCount);
        foreach (TileDot dot in dots)
        {
            dot.View.color = _colorsMap[dotCount];
        }
    }

    private void ColorFace(SpriteRenderer face)
    {
        face.color = _themeConfig.TileFaceColor;
    }

    private void ColorEdge(SpriteRenderer edge)
    {
        edge.color = _themeConfig.TileEdgeColor;
    }
}
