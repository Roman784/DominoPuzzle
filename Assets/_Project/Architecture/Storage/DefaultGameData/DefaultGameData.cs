using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameData", menuName = "GameData/Default")]
public class DefaultGameData : ScriptableObject
{
    [field: SerializeField] public GameData GameData { get; private set; }
}
