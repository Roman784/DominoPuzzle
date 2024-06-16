using UnityEngine;
using Zenject;

public class BackgroundCreator : MonoBehaviour
{
    public static int id; // <- ������ � �������� �� �������� �� ��

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
