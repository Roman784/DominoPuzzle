using UnityEngine;

[CreateAssetMenu(fileName = "FieldConfig", menuName = "Configs/Field/Field")]
public class FieldConfig : ScriptableObject
{
    [field: SerializeField] public float TileSpacing { get; private set; }
}