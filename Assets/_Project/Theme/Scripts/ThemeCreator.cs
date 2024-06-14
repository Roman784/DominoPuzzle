using UnityEngine;
using System.Linq;
using Zenject;

public class ThemeCreator
{
    private Theme _createdTheme;

    private ThemeCreationConfig _config;

    [Inject]
    private void Construct(ThemeCreationConfig config)
    {
        _config = config;

        Create(0);
    }

    public void Set(int id)
    {
        if (_createdTheme != null)
            GameObject.Destroy(_createdTheme.gameObject);

        Create(id);
    }

    private void Create(int id)
    {
        Theme prefab = GetThemePrefab(id);

        if (prefab == null) return;

        Theme theme = GameObject.Instantiate(prefab, Vector2.zero, Quaternion.identity, null);

        _createdTheme = theme;
    }

    private Theme GetThemePrefab(int id)
    {
        return _config.ThemePrefabsMap.FirstOrDefault(p => p.Id == id).Prefab;
    }
}
