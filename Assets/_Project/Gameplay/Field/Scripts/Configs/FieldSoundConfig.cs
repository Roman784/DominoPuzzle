using UnityEngine;

[CreateAssetMenu(fileName = "FieldSoundConfig", menuName = "Configs/Field/Sound")]
public class FieldSoundConfig : ScriptableObject
{
    [field: SerializeField] public AudioClip FieldCompleteSound {  get; private set; }
}
