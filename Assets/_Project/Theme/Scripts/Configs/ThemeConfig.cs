using UnityEngine;

[CreateAssetMenu(fileName = "ThemeConfig", menuName = "Configs/Theme/Theme")]
public class ThemeConfig : ScriptableObject
{
    [field: SerializeField] public Color MainColor {  get; private set; }
    [field: SerializeField] public Color TileFaceColor { get; private set; }
    [field: SerializeField] public Color TileEdgeColor { get; private set; }
    [field: SerializeField] public Color OneDotColor { get; private set; }
    [field: SerializeField] public Color TwoDotColor { get; private set; }
    [field: SerializeField] public Color ThreeDotColor { get; private set; }
    [field: SerializeField] public Color FourDotColor { get; private set; }
}
