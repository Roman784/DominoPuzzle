using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldSpawnConfig", menuName = "Configs/FieldSpawnConfig")]
public class FieldSpawnConfig : ScriptableObject
{
    [field: SerializeField] public List<Field> Fields {  get; private set; }
}
