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
    }

    public Theme Create(int id)
    {
        Theme prefab = GetThemePrefab(id);

        if (prefab == null) return null;

        Theme theme = GameObject.Instantiate(prefab, Vector2.zero, Quaternion.identity, null);

        _createdTheme = theme;

        return theme;
    }

    public void DestroyCreatedTheme()
    {
        if (_createdTheme == null) return;

        GameObject.Destroy(_createdTheme.gameObject);
    }

    private Theme GetThemePrefab(int id)
    {
        return _config.ThemePrefabsMap.FirstOrDefault(p => p.Id == id).Prefab;
    }
}
