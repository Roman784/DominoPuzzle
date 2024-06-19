using UnityEngine;
using System.Linq;
using Zenject;

public class ThemeCreator
{
    private ThemeCreationConfig _config;

    [Inject]
    private void Construct(ThemeCreationConfig config)
    {
        _config = config;
    }

    public Theme Create(int id)
    {
        Theme prefab = GetThemePrefab(id);

        if (prefab == null) return null;

        Theme theme = GameObject.Instantiate(prefab, Vector2.zero, Quaternion.identity, null);

        return theme;
    }

    private Theme GetThemePrefab(int id)
    {
        return _config.ThemePrefabsMap.FirstOrDefault(p => p.Id == id).Prefab;
    }
}
