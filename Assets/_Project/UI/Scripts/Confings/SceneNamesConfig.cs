using UnityEngine;

[CreateAssetMenu(fileName = "SceneNamesConfig", menuName = "Configs/Menu/SceneNames")]
public class SceneNamesConfig : ScriptableObject
{
    [field: SerializeField] public string LevelList {  get; private set; }
    [field: SerializeField] public string GameplayScene { get; private set; }
    [field: SerializeField] public string ThemeOptions { get; private set; }
}
