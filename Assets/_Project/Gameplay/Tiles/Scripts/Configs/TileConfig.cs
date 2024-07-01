using UnityEngine;

[CreateAssetMenu(fileName = "TileConfig", menuName = "Configs/Tile/Tile")]
public class TileConfig : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: Space]
    [field: SerializeField] public AudioClip FallSound { get; private set; }
    [field: SerializeField] public AudioClip LiftSound { get; private set; }
}