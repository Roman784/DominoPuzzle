using System;
using UnityEngine;

[Serializable]
public class TileDot
{
    [field: SerializeField] public GameObject Dot { get; private set; }
    [field: SerializeField] public DotPosition Position { get; private set; }
    [field: SerializeField] public bool IsActive { get; private set; }
}
