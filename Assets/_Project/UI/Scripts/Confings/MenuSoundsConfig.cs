using UnityEngine;

[CreateAssetMenu(fileName = "MenuSoundsConfig", menuName = "Configs/Menu/Sounds")]
public class MenuSoundsConfig : ScriptableObject
{
    [field: SerializeField] public AudioClip ButtonClickSound { get; private set; }
}