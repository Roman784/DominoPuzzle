using UnityEngine;
using System.Linq;
using Zenject;

public class ThemeCreator
{
    private ThemeCreationConfig _config;
    private DiContainer _container;

    [Inject]
    private void Construct(ThemeCreationConfig config, DiContainer container)
    {
        _config = config;
        _container = container;
    }

    public Theme Create(int id)
    {
        Theme prefab = GetThemePrefab(id);

        if (prefab == null) return null;

        Theme theme = _container.InstantiatePrefab(prefab, Vector2.zero, Quaternion.identity, null).GetComponent<Theme>();

        return theme;
    }

    private Theme GetThemePrefab(int id)
    {
        return _config.ThemePrefabsMap.FirstOrDefault(p => p.Id == id).Prefab;
    }
}
