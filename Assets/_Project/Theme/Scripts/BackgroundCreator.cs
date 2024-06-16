using UnityEngine;
using Zenject;

public class BackgroundCreator : MonoBehaviour
{
    public static int id; // <- убрать и заменить на загрузку из бд

    [Inject]
    private void Construct(ThemeCreator themeCreator)
    {
        Create(themeCreator);
    }

    private void Create(ThemeCreator themeCreator)
    {
        Theme theme = themeCreator.Create(id);
        theme.DeactivateTitle();
    }
}
