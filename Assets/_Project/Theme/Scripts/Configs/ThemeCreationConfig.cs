using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeCreationConfig", menuName = "Configs/Theme/Themes")]
public class ThemeCreationConfig : ScriptableObject
{
    [field: SerializeField] public List<ThemePrefabItem> ThemePrefabsMap { get; private set; }

    private void OnValidate()
    {
        ValidateThemeIds();
    }

    // Checking for matching theme ids.
    private void ValidateThemeIds()
    {
        for (int i = 0; i < ThemePrefabsMap.Count; i++)
        {
            for (int j = i + 1; j < ThemePrefabsMap.Count; j++)
            {
                int id1 = ThemePrefabsMap[i].Id;
                int id2 = ThemePrefabsMap[j].Id;

                if (id1 == id2)
                    throw new Exception($"The theme id {id1} already exists.");
            }
        }
    }
}
