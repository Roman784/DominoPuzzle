using UnityEngine;

[CreateAssetMenu(fileName = "SceneNamesConfig", menuName = "Configs/Architecture/SceneNames")]
public class SceneNamesConfig : ScriptableObject
{
    [field: SerializeField] public string MainMenu {  get; private set; }
    [field: SerializeField] public string GameplayScene { get; private set; }
}
