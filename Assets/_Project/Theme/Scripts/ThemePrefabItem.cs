using System;
using UnityEngine;

[Serializable]
public class ThemePrefabItem
{
    [field: SerializeField] public int Id {  get; private set; }
    [field: SerializeField] public Theme Prefab {  get; private set; }
}
