using System;
using UnityEngine;

[Serializable]
public sealed class FieldPrefabItem
{
    [field: SerializeField] public int Number { get; private set; }
    [field: SerializeField] public Field Prefab { get; private set; }
}
