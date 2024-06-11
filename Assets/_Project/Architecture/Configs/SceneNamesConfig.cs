using UnityEngine;

[CreateAssetMenu(fileName = "SceneNamesConfig", menuName = "Configs/Architecture/SceneNames")]
public class SceneNamesConfig : ScriptableObject
{
    [field: SerializeField] public string LevelList {  get; private set; }
    [field: SerializeField] public string GameplayScene { get; private set; }
}
