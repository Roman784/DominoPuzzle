using UnityEngine;

[CreateAssetMenu(fileName = "FieldAnimationConfig", menuName = "Configs/Field/Animation")]
public class FieldAnimationConfig : ScriptableObject
{
    [field: SerializeField] public float TileAppearanceDelay { get; private set; }
    [field: SerializeField] public float TileDisappearanceDelay { get; private set; }
    [field: SerializeField] public float TileShufflingDelay { get; private set; }
}
