using UnityEngine;

[CreateAssetMenu(fileName = "TileConfig", menuName = "Configs/Tile/Tile")]
public class TileConfig : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
}